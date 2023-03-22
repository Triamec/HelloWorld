# Hello World!
The *Hello World!* sample application helps you to start up a Triamec Drive.

However, since the configuration of a drive for any motor is not trivial, you may have to consult further documents. Visit our [website](https://www.triamec.com/en/documents.html) for more information.

## Preparation
### Required Hardware
In order to start up a Triamec Drive, one of the following connections/interfaces is required:
- Tria-Link (PCI-Board)
- USB
- Ethernet

### Connect the Drive
1. Connect the motor, encoder and power supplies to the Drive. Further information can be found in the corresponding hardware manual.
2. Connect the communication interface.

## Software
### Required Software
For the programming you need an IDE. For example you can use [Microsoft Visual Studio](https://visualstudio.microsoft.com/en/).

In addition you need also the TAM Software for Triamec Products. The latest version you can find [here](https://www.triamec.com/en/tam-software-support.html). Herewith, all the the required drivers will be installed.

### Configure the Drive
The drive needs to be setup for the corresponding motor and encoder.
1. Start the *TAM System Explorer*
2. Comission the drive using the [Servo Drive Setup Guide](https://www.triamec.com/de/dokumente.html).
3. **Remove** the **Axis Group** in the configuration.
4. Save the TAM Configuration and overwrite the **`HelloWorldTamConfiguration.xml`**.
5. **Close** the *TAM System Explorer*

## Start the *Hello World!* Application
1. Open the `Hello World!.sln` in your IDE.
2. Open the `HelloWorldForm.cs` (view code)
3. If necessary, adjust the `Distance` constant to the cicumstances.
4. Set the `Simulated`constant to `false`, otherwise a simulated environment will be built without any hardware. Consider, that the simulation emulates only few properties.
5. Start the application

## Operate the *Hello World!* Application
1. Press `Enable` to switch on the control. Behind the button, the `EnableDrive()` method is called. As can be seen from the code, it takes two actions to control the axis. First the power section must be switched on, then the axis control. The same applies when switching off the regulation. 
2. Press 'Left' and 'Right'. The motor turns 1/4 in the appropriate direction. The speed can be changed with the slider.
3. Press `Disable`to switch off


