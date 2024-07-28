using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Converters;
using XboxToKeyboard.Utils;

namespace XboxToKeyboard;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    ConsoleManager consoleManager;
    ConnectionStatusManager connectionStatusManager;
    GamepadManager gamePad;
    GamePadBinding binding;
    public MainWindow()
    {
        InitializeComponent();
        consoleManager = new ConsoleManager(listboxConsole);
        connectionStatusManager = new ConnectionStatusManager(labelConnectionStatus, buttonConnectController);
        gamePad = new GamepadManager(connectionStatusManager, consoleManager, this.Dispatcher);
        binding = Serializer.DeserializeFromFile();
        if(binding == null ) {
            binding = new GamePadBinding();
        }
        UpdateConfig();

        connectionStatusManager.Disconnected();
        
        gamePad.ButtonDown += (sender, button) => this.Dispatcher.Invoke(() => { ButtonDown(button); }); ;
        gamePad.ButtonUp += (sender, button) => this.Dispatcher.Invoke(() => { ButtonUp(button); }); ;
    }

    async void StartGamePad()
    {
        if(gamePad.ConnectController())
        await gamePad.StartAsync();
    }

    private void buttonConnectController_Click(object sender, RoutedEventArgs e)
    {
        StartGamePad();
    }

    private void UpdateConfig()
    {
        buttonXboxLeftTrigger.Content = binding.LeftTrigger ?? "";
        buttonXboxLeftBumper.Content = binding.LeftBumper ?? "";
        buttonXboxRightTrigger.Content = binding.RightTrigger ?? "";
        buttonXboxRightBumper.Content = binding.RightBumper ?? "";
        buttonXboxLeftAnalogUp.Content = binding.LeftAnalogUp ?? "";
        buttonXboxLeftAnalogDown.Content = binding.LeftAnalogDown ?? "";
        buttonXboxLeftAnalogLeft.Content = binding.LeftAnalogLeft ?? "";
        buttonXboxLeftAnalogRight.Content = binding.LeftAnalogRight ?? "";
        buttonXboxLeftAnalog.Content = binding.LeftAnalog ?? "";
        buttonXboxRightAnalogUp.Content = binding.RightAnalogUp ?? "";
        buttonXboxRightAnalogDown.Content = binding.RightAnalogDown ?? "";
        buttonXboxRightAnalogLeft.Content = binding.RightAnalogLeft ?? "";
        buttonXboxRightAnalogRight.Content = binding.RightAnalogRight ?? "";
        buttonXboxRightAnalog.Content = binding.RightAnalog ?? "";
        buttonXboxDpadUp.Content = binding.DpadUp ?? "";
        buttonXboxDpadDown.Content = binding.DpadDown ?? "";
        buttonXboxDpadLeft.Content = binding.DpadLeft ?? "";
        buttonXboxDpadRight.Content = binding.DpadRight ?? "";
        buttonXboxStart.Content = binding.Start ?? "";
        buttonXboxSelect.Content = binding.Select ?? "";
        buttonXboxX.Content = binding.X ?? "";
        buttonXboxY.Content = binding.Y ?? "";
        buttonXboxA.Content = binding.A ?? "";
        buttonXboxB.Content = binding.B ?? "";
    }

    private void ButtonDown(ExtendedGamepadButtonFlags button)
    {
        consoleManager.Add($"{button} Down");
        var CODE = SearchKey(button);
        KeyboardManager.SimulateKeyPress(CODE);
    }

    private void ButtonUp(ExtendedGamepadButtonFlags button)
    {
        consoleManager.Add($"{button} Up");
        KeyboardManager.SimulateKeyRelease(SearchKey(button));
    }

    private ushort SearchKey(ExtendedGamepadButtonFlags button)
    {
        switch (button) {
            case ExtendedGamepadButtonFlags.DPadUp:
                return Keycodes.KeyCode(binding.DpadUp);   
            case ExtendedGamepadButtonFlags.DPadDown:
                return Keycodes.KeyCode(binding.DpadDown);
            case ExtendedGamepadButtonFlags.DPadRight:
                return Keycodes.KeyCode(binding.DpadRight);
            case ExtendedGamepadButtonFlags.DPadLeft:
                return Keycodes.KeyCode(binding.DpadLeft);
            case ExtendedGamepadButtonFlags.RightTrigger:
                return Keycodes.KeyCode(binding.RightTrigger);
            case ExtendedGamepadButtonFlags.LeftTrigger:
                return Keycodes.KeyCode(binding.LeftTrigger);
            case ExtendedGamepadButtonFlags.RightShoulder:
                return Keycodes.KeyCode(binding.RightBumper);
            case ExtendedGamepadButtonFlags.LeftShoulder:
                return Keycodes.KeyCode(binding.LeftBumper);
            case ExtendedGamepadButtonFlags.Start:
                return Keycodes.KeyCode(binding.Start);
            case ExtendedGamepadButtonFlags.Back:
                return Keycodes.KeyCode(binding.Select);
            case ExtendedGamepadButtonFlags.A:
                return Keycodes.KeyCode(binding.A);
            case ExtendedGamepadButtonFlags.B:
                return Keycodes.KeyCode(binding.B);
            case ExtendedGamepadButtonFlags.X:
                return Keycodes.KeyCode(binding.X);
            case ExtendedGamepadButtonFlags.Y:
                return Keycodes.KeyCode(binding.Y);
           case ExtendedGamepadButtonFlags.LeftThumbstickUp:
                return Keycodes.KeyCode(binding.LeftAnalogUp);
            case ExtendedGamepadButtonFlags.LeftThumbstickDown:
                return Keycodes.KeyCode(binding.LeftAnalogDown);
            case ExtendedGamepadButtonFlags.LeftThumbstickRight:
                return Keycodes.KeyCode(binding.LeftAnalogRight);
            case ExtendedGamepadButtonFlags.LeftThumbstickLeft:
                return Keycodes.KeyCode(binding.LeftAnalogLeft);
            case ExtendedGamepadButtonFlags.RightThumbstickUp:
                return Keycodes.KeyCode(binding.RightAnalogUp);
            case ExtendedGamepadButtonFlags.RightThumbstickDown:
                return Keycodes.KeyCode(binding.RightAnalogDown);
             case ExtendedGamepadButtonFlags.RightThumbstickRight:
                   return Keycodes.KeyCode(binding.RightAnalogRight);
               case ExtendedGamepadButtonFlags.RightThumbstickLeft:
                   return Keycodes.KeyCode(binding.RightAnalogLeft);
            case ExtendedGamepadButtonFlags.RightThumb:
                return Keycodes.KeyCode(binding.RightAnalog);
            case ExtendedGamepadButtonFlags.LeftThumb:
                return Keycodes.KeyCode(binding.LeftAnalog);
            default:
                return 0;
        }
    }

    private void buttonXboxLeftTrigger_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.LeftTrigger = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxLeftBumper_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.LeftBumper = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxRightTrigger_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.RightTrigger = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxRightBumper_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.RightBumper = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxLeftAnalogUp_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.LeftAnalogUp = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxLeftAnalogLeft_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.LeftAnalogLeft = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxLeftAnalogDown_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.LeftAnalogDown = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxLeftAnalogRight_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.LeftAnalogRight = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxDpadUp_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.DpadUp = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxDpadLeft_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.DpadLeft = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxDpadDown_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.DpadDown = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxDpadRight_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.DpadRight = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxSelect_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.Select = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxStart_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.Start = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxRightAnalogUp_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.RightAnalogUp = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxRightAnalogLeft_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.RightAnalogLeft = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxRightAnalogDown_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.RightAnalogDown = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxRightAnalogRight_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.RightAnalogRight = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxY_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.Y = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxX_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.X = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxA_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.A = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxB_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.B = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonSaveConfig_Click(object sender, RoutedEventArgs e)
    {
        binding.SerializeToFile();
    }

    private void buttonXboxLeftAnalog_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.LeftAnalog = setBinding.KeyPressed();
            UpdateConfig();
        }
    }

    private void buttonXboxRightAnalog_Click(object sender, RoutedEventArgs e)
    {
        SetBinding setBinding = new SetBinding();
        setBinding.ShowDialog();
        if (setBinding.Save())
        {
            binding.RightAnalog = setBinding.KeyPressed();
            UpdateConfig();
        }
    }
}