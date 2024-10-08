﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Triamec.Tam.Configuration;
using Triamec.Tam.Samples.Properties;
using Triamec.TriaLink;
using Triamec.TriaLink.Adapter;

// Rlid19 represents the register layout of drives of the current generation. A previous generation drive has layout 4.
using Axis = Triamec.Tam.Rlid19.Axis;

namespace Triamec.Tam.Samples {
    /// <summary>
    /// The main form of the TAM "Hello World!" application.
    /// </summary>
    internal partial class HelloWorldForm : Form {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="HelloWorldForm"/> class.
        /// </summary>
        public HelloWorldForm() {
            InitializeComponent();
        }
        #endregion Constructor

        #region Hello world code
        /// <summary>
        /// The distance to move when pressing one of the move buttons.
        /// </summary>
        // CAUTION!
        // The unit of this constant depends on the PositionUnit parameter provided with the TAM configuration.
        // Additionally, the encoder must be correctly configured.
        // Consider any limit stops.
        const double Distance = 0.5 * Math.PI;

        /// <summary>
        /// Whether to use a (rather simplified) simulation of the axis.
        /// </summary>
        // CAUTION!
        // Ensure the above constants are properly configured before setting this to false.
        readonly bool _offline = true;

        /// <summary>
        /// The configuration file to seed the simulation.
        /// </summary>
        const string OfflineConfigurationPath = "HelloWorld.TAMcfg";

        TamTopology _topology;
        TamAxis _axis;

        float _velocityMaximum;
        string _unit;

        /// <summary>
        /// Prepares the TAM system.
        /// </summary>
        /// <exception cref="TamException">Startup failed.</exception>
        /// <exception cref="Triamec.Configuration.ConfigurationException">Failed to load the configuration.</exception>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<item><description>Creates a TAM topology,</description></item>
        /// 		<item><description>boots the Tria-Link,</description></item>
        /// 		<item><description>searches for a servo-drive,</description></item>
        /// 		<item><description>loads and applies a TAM configuration.</description></item>
        /// 	</list>
        /// </remarks>
        void Startup() {

            // Create the root object representing the topology of the TAM hardware.
            // We will dispose this object via components.
            _topology = new TamTopology();
            components.Add(_topology);

            TamSystem system;
            if (_offline) {
                string executablePath = AppDomain.CurrentDomain.BaseDirectory;
                using (var deserializer = new Deserializer()) {

                    // Load and add a simulated TAM system as defined in the .TAMcfg file.
                    deserializer.Load(Path.Combine(executablePath, OfflineConfigurationPath));
                    var adapters = CreateSimulatedTriaLinkAdapters(deserializer.Configuration).First();
                    system = _topology.ConnectTo(adapters.Key, adapters.ToArray());

                    // Boot the Tria-Link so that it learns about connected stations.
                    system.Identify();
                }

                // Load a TAM configuration.
                // This API doesn't feature GUI. Refer to the Gear Up! example which uses an API exposing a GUI.
                _topology.Load(OfflineConfigurationPath);
            } else {

                // Add the local TAM system on this PC to the topology.
                system = _topology.AddLocalSystem();

                // Boot the Tria-Link so that it learns about connected stations.
                system.Identify();

                // Don't load TAM configuration, assuming that the drive is already configured,
                // for example since parametrization is persisted in the drive.
            }

            // Find the axis with the configured name in the Tria-Link.
            // The AsDepthFirstLeaves extension method performs a tree search an returns all instances of type TamAxis.
            // "Leaves" means that the search doesn't continue within TamAxis nodes.
            // CAUTION!
            // Selecting the wrong axis can have unintended consequences.
            // The Acquisition sample shows how to locate an axis based on its name.
            _axis = system.AsDepthFirstLeaves<TamAxis>().FirstOrDefault();
            if (_axis == null) throw new TamException(Resources.NoAxisMessage);

            // Most drives get integrated into a real time control system. Accessing them via TAM API like we do here is considered
            // a secondary use case. Tell the axis that we're going to take control. Otherwise, the axis might reject our commands.
            // You should not do this, though, when this application is about to access the drive via the PCI interface.
            _axis.ControlSystemTreatment.Override(enabled: true);

            // Simulation always starts up with LinkNotReady error, which we acknowledge.
            if (_offline) _axis.Drive.ResetFault();

            // Get the register layout of the axis
            // and cast it to the RLID-specific register layout.
            var register = (Axis)_axis.Register;

            // Read and cache the original velocity maximum value,
            // which was applied from the configuration file.
            _velocityMaximum = register.Parameters.PathPlanner.VelocityMaximum.Read();

            // Cache the position unit.
            _unit = register.Parameters.PositionController.PositionUnit.Read().ToString();

            // Start displaying the position in regular intervals.
            _timer.Start();
        }

        /// <summary>
        /// Creates simulated Tria-Link adapters from a specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The newly created simulated Tria-Link adapters.</returns>
        static IEnumerable<IGrouping<Uri, ITriaLinkAdapter>> CreateSimulatedTriaLinkAdapters(
            TamTopologyConfiguration configuration) =>

            // This call must be in this extra method such that the Tam.Simulation library is only loaded
            // when simulating. This happens when this method is jitted because the SimulationFactory is the first
            // symbol during runtime originating from the Tam.Simulation library.
            SimulationFactory.FromConfiguration(configuration, null);

        /// <exception cref="TamException">Enabling failed.</exception>
        void EnableAxis() {
            if (_axis.Drive.Station.Link.Adapter.IsSimulated) {

                // [LEGACY] Set the drive operational, i.e. switch the power section on
                _axis.Drive.SwitchOn();
            }

            // Reset any axis error and enable the axis controller.
            _axis.Control(AxisControlCommands.ResetErrorAndEnable);
        }

        /// <exception cref="TamException">Disabling failed.</exception>
        void DisableAxis() {

            // Disable the axis controller.
            _axis.Control(AxisControlCommands.Disable);

            if (_axis.Drive.Station.Link.Adapter.IsSimulated) {

                // [LEGACY] Switch the power section off.
                _axis.Drive.SwitchOff();
            }
        }

        /// <summary>
        /// Moves in the specified direction.
        /// </summary>
        /// <param name="sign">A positive or negative value indicating the direction of the motion.</param>
        /// <exception cref="TamException">Moving failed.</exception>
        void MoveAxis(int sign) =>

            // Move a distance with dedicated velocity.
            // If the axis is just moving, it is reprogrammed with this command.
            // Please note that in offline mode, the velocity parameter is ignored.
            _axis.MoveRelative(Math.Sign(sign) * Distance, _velocityMaximum * _velocitySlider.Value * 0.01f);

        /// <summary>
        /// Measures the axis position and shows it in the GUI.
        /// </summary>
        void ReadPosition() {
            var register = (Axis)_axis.Register;
            var positionRegister = register.Signals.PositionController.MasterPosition;
            var position = positionRegister.Read();
            _positionBox.Text = $"{position:F6} {_unit}";
        }
        #endregion Hello world code

        #region GUI handler methods
        #region Form handler methods

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            try {
                Startup();
                _driveGroupBox.Enabled = true;
            } catch (TamException ex) {
                MessageBox.Show(this, ex.FullMessage(), Resources.StartupErrorCaption, MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e) {
            base.OnFormClosed(e);
            if (_axis != null) {
                try {
                    DisableAxis();
                } catch (TamException ex) {
                    MessageBox.Show(this, ex.Message, Resources.StartupErrorCaption, MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                }
            }
        }
        #endregion Form handler methods

        #region Button handler methods

        void ExecuteCommand(Action command) {
            try {
                command();
            } catch (TamException ex) {
                MessageBox.Show(ex.Message, Resources.EnablingErrorCaption, MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0);
            }
        }

        void OnEnableButtonClick(object sender, EventArgs e) {
            ExecuteCommand(EnableAxis);

            // Note: a more elaborated application would change button states depending on what's the drive reporting,
            // following the MVC concept.
            _moveNegativeButton.Enabled = true;
            _movePositiveButton.Enabled = true;
        }

        void OnDisableButtonClick(object sender, EventArgs e) {
            _moveNegativeButton.Enabled = false;
            _movePositiveButton.Enabled = false;
            ExecuteCommand(DisableAxis);
        }

        void OnMoveNegativeButtonClick(object sender, EventArgs e) => ExecuteCommand(() => MoveAxis(-1));

        void OnMovePositiveButtonClick(object sender, EventArgs e) => ExecuteCommand(() => MoveAxis(1));

        #endregion Button handler methods

        #region Menu handler methods

        void OnExitMenuItemClick(object sender, EventArgs e) => Close();
        #endregion Menu handler methods

        #region Timer methods
        void OnTimerTick(object sender, EventArgs e) => ReadPosition();

        #endregion Timer methods
        #endregion GUI handler methods
    }
}
