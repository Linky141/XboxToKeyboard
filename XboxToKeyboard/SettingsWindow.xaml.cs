using System.Windows;
using System.Windows.Controls;
using XboxToKeyboard.Utils;

namespace XboxToKeyboard;

/// <summary>
/// Interaction logic for SettingsWindow.xaml
/// </summary>
public partial class SettingsWindow : Window
{
    short analogDeadzoneDefaultValue = 5000;
    short AnalogDeadzone;
    GamepadManager gamePad;
    const short analogDeadzoneMaximumValue = 25000;
    const short analogDeadzoneMinimumValue = 3000;
    private readonly static string _thumbstickDeadzoneConfigPath = "ThumbstickDeadzoneConfig.json";

    public SettingsWindow(GamepadManager gamePad)
    {
        InitializeComponent();
        sliderAnalogDeadzone.Minimum = analogDeadzoneMinimumValue;
        sliderAnalogDeadzone.Maximum = analogDeadzoneMaximumValue;
        this.gamePad = gamePad;
        AnalogDeadzone = gamePad.GetThumbstickDeadzone();
        gamePad.ButtonDown += (sender, button) => this.Dispatcher.Invoke(() => { ButtonDown(button); }); 
        gamePad.ButtonUp += (sender, button) => this.Dispatcher.Invoke(() => { ButtonUp(button); }); 

        syncControlsAnalogDeadzone(AnalogDeadzone);
    }

    private void ButtonDown(ExtendedGamepadButtonFlags button)
    {
        CheckButtonPressed(button, true);
    }

    private void ButtonUp(ExtendedGamepadButtonFlags button)
    {
        CheckButtonPressed(button, false);
    }

    private void CheckButtonPressed(ExtendedGamepadButtonFlags button, bool state)
    {
        switch (button)
        {
            case ExtendedGamepadButtonFlags.LeftThumbstickUp:
            case ExtendedGamepadButtonFlags.RightThumbstickUp:
                if(state) labelArrowUp.Visibility = Visibility.Visible;
                else labelArrowUp.Visibility = Visibility.Hidden;
                break;
            case ExtendedGamepadButtonFlags.LeftThumbstickDown:
            case ExtendedGamepadButtonFlags.RightThumbstickDown:
                if (state) labelArrowDown.Visibility = Visibility.Visible;
                else labelArrowDown.Visibility = Visibility.Hidden;
                break;
            case ExtendedGamepadButtonFlags.LeftThumbstickLeft:
            case ExtendedGamepadButtonFlags.RightThumbstickLeft:
                if (state) labelArrowLeft.Visibility = Visibility.Visible;
                else labelArrowLeft.Visibility = Visibility.Hidden;
                break;
            case ExtendedGamepadButtonFlags.LeftThumbstickRight:
            case ExtendedGamepadButtonFlags.RightThumbstickRight:
                if (state) labelArrowRight.Visibility = Visibility.Visible;
                else labelArrowRight.Visibility = Visibility.Hidden;
                break;
            default:
                break;
        }
    }

    private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        syncControlsAnalogDeadzone((short)sliderAnalogDeadzone.Value);
    }

    private void textboxAnalogDeadzone_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(short.TryParse(textboxAnalogDeadzone.Text, out short value) && value >= analogDeadzoneMinimumValue && value <= analogDeadzoneMaximumValue)
            {
            syncControlsAnalogDeadzone(value);
        }
        else { syncControlsAnalogDeadzone(analogDeadzoneDefaultValue); }
    }

    private void syncControlsAnalogDeadzone(short value)
    {
        sliderAnalogDeadzone.Value = value;
        textboxAnalogDeadzone.Text = value.ToString();
        if(gamePad != null) gamePad.SetThumbstickDeadzone(value);
        AnalogDeadzone = value;

    }

    private void buttonThumbstickDeadzoneSave_Click(object sender, RoutedEventArgs e)
    {
        Serializer.SerializeToFile(AnalogDeadzone, _thumbstickDeadzoneConfigPath);
    }
}
