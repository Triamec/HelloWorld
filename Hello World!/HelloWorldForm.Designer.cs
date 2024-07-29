namespace Triamec.Tam.Samples {
    partial class HelloWorldForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button enableButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelloWorldForm));
            System.Windows.Forms.Button disableButton;
            System.Windows.Forms.MenuStrip menuStrip;
            System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem exitMenuItem;
            System.Windows.Forms.GroupBox motionGroupBox;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.GroupBox measurementGroupBox;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Button f1Button;
            System.Windows.Forms.Button f2Button;
            this._velocitySlider = new System.Windows.Forms.TrackBar();
            this._moveNegativeButton = new System.Windows.Forms.Button();
            this._movePositiveButton = new System.Windows.Forms.Button();
            this._measurement3Box = new System.Windows.Forms.TextBox();
            this._measurement2Box = new System.Windows.Forms.TextBox();
            this._positionBox = new System.Windows.Forms.TextBox();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._driveGroupBox = new System.Windows.Forms.GroupBox();
            this._timer = new System.Windows.Forms.Timer(this.components);
            enableButton = new System.Windows.Forms.Button();
            disableButton = new System.Windows.Forms.Button();
            menuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            motionGroupBox = new System.Windows.Forms.GroupBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            measurementGroupBox = new System.Windows.Forms.GroupBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            f1Button = new System.Windows.Forms.Button();
            f2Button = new System.Windows.Forms.Button();
            menuStrip.SuspendLayout();
            motionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._velocitySlider)).BeginInit();
            measurementGroupBox.SuspendLayout();
            this._driveGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // enableButton
            // 
            resources.ApplyResources(enableButton, "enableButton");
            enableButton.Name = "enableButton";
            this._toolTip.SetToolTip(enableButton, resources.GetString("enableButton.ToolTip"));
            enableButton.UseVisualStyleBackColor = true;
            enableButton.Click += new System.EventHandler(this.OnEnableButtonClick);
            // 
            // disableButton
            // 
            resources.ApplyResources(disableButton, "disableButton");
            disableButton.Name = "disableButton";
            this._toolTip.SetToolTip(disableButton, resources.GetString("disableButton.ToolTip"));
            disableButton.UseVisualStyleBackColor = true;
            disableButton.Click += new System.EventHandler(this.OnDisableButtonClick);
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileToolStripMenuItem});
            resources.ApplyResources(menuStrip, "menuStrip");
            menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            exitMenuItem});
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            resources.ApplyResources(exitMenuItem, "exitMenuItem");
            exitMenuItem.Click += new System.EventHandler(this.OnExitMenuItemClick);
            // 
            // motionGroupBox
            // 
            motionGroupBox.Controls.Add(label3);
            motionGroupBox.Controls.Add(label2);
            motionGroupBox.Controls.Add(label1);
            motionGroupBox.Controls.Add(this._velocitySlider);
            motionGroupBox.Controls.Add(this._moveNegativeButton);
            motionGroupBox.Controls.Add(this._movePositiveButton);
            resources.ApplyResources(motionGroupBox, "motionGroupBox");
            motionGroupBox.Name = "motionGroupBox";
            motionGroupBox.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // _velocitySlider
            // 
            resources.ApplyResources(this._velocitySlider, "_velocitySlider");
            this._velocitySlider.LargeChange = 10;
            this._velocitySlider.Maximum = 100;
            this._velocitySlider.Minimum = 10;
            this._velocitySlider.Name = "_velocitySlider";
            this._velocitySlider.TickFrequency = 5;
            this._toolTip.SetToolTip(this._velocitySlider, resources.GetString("_velocitySlider.ToolTip"));
            this._velocitySlider.Value = 100;
            // 
            // _moveNegativeButton
            // 
            resources.ApplyResources(this._moveNegativeButton, "_moveNegativeButton");
            this._moveNegativeButton.Name = "_moveNegativeButton";
            this._toolTip.SetToolTip(this._moveNegativeButton, resources.GetString("_moveNegativeButton.ToolTip"));
            this._moveNegativeButton.UseVisualStyleBackColor = true;
            this._moveNegativeButton.Click += new System.EventHandler(this.OnMoveNegativeButtonClick);
            // 
            // _movePositiveButton
            // 
            resources.ApplyResources(this._movePositiveButton, "_movePositiveButton");
            this._movePositiveButton.Name = "_movePositiveButton";
            this._toolTip.SetToolTip(this._movePositiveButton, resources.GetString("_movePositiveButton.ToolTip"));
            this._movePositiveButton.UseVisualStyleBackColor = true;
            this._movePositiveButton.Click += new System.EventHandler(this.OnMovePositiveButtonClick);
            // 
            // measurementGroupBox
            // 
            measurementGroupBox.Controls.Add(this._measurement3Box);
            measurementGroupBox.Controls.Add(this._measurement2Box);
            measurementGroupBox.Controls.Add(this._positionBox);
            measurementGroupBox.Controls.Add(label6);
            measurementGroupBox.Controls.Add(label5);
            measurementGroupBox.Controls.Add(label4);
            resources.ApplyResources(measurementGroupBox, "measurementGroupBox");
            measurementGroupBox.Name = "measurementGroupBox";
            measurementGroupBox.TabStop = false;
            // 
            // _measurement3Box
            // 
            resources.ApplyResources(this._measurement3Box, "_measurement3Box");
            this._measurement3Box.Name = "_measurement3Box";
            this._measurement3Box.ReadOnly = true;
            // 
            // _measurement2Box
            // 
            resources.ApplyResources(this._measurement2Box, "_measurement2Box");
            this._measurement2Box.Name = "_measurement2Box";
            this._measurement2Box.ReadOnly = true;
            // 
            // _positionBox
            // 
            resources.ApplyResources(this._positionBox, "_positionBox");
            this._positionBox.Name = "_positionBox";
            this._positionBox.ReadOnly = true;
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // f1Button
            // 
            resources.ApplyResources(f1Button, "f1Button");
            f1Button.Name = "f1Button";
            f1Button.UseVisualStyleBackColor = true;
            f1Button.Click += new System.EventHandler(this.OnF1ButtonClick);
            // 
            // f2Button
            // 
            resources.ApplyResources(f2Button, "f2Button");
            f2Button.Name = "f2Button";
            f2Button.UseVisualStyleBackColor = true;
            f2Button.Click += new System.EventHandler(this.OnF2ButtonClick);
            // 
            // _driveGroupBox
            // 
            this._driveGroupBox.Controls.Add(enableButton);
            this._driveGroupBox.Controls.Add(disableButton);
            resources.ApplyResources(this._driveGroupBox, "_driveGroupBox");
            this._driveGroupBox.Name = "_driveGroupBox";
            this._driveGroupBox.TabStop = false;
            // 
            // _timer
            // 
            this._timer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // HelloWorldForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(measurementGroupBox);
            this.Controls.Add(motionGroupBox);
            this.Controls.Add(this._driveGroupBox);
            this.Controls.Add(menuStrip);
            this.Controls.Add(f2Button);
            this.Controls.Add(f1Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = menuStrip;
            this.Name = "HelloWorldForm";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            motionGroupBox.ResumeLayout(false);
            motionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._velocitySlider)).EndInit();
            measurementGroupBox.ResumeLayout(false);
            measurementGroupBox.PerformLayout();
            this._driveGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _moveNegativeButton;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.Button _movePositiveButton;
        private System.Windows.Forms.GroupBox _driveGroupBox;
        private System.Windows.Forms.TrackBar _velocitySlider;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.TextBox _positionBox;
        private System.Windows.Forms.TextBox _measurement3Box;
        private System.Windows.Forms.TextBox _measurement2Box;
    }
}

