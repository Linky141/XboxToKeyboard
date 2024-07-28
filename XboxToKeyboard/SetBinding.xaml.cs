using System.Windows;

namespace XboxToKeyboard;

/// <summary>
/// Interaction logic for SetBinding.xaml
/// </summary>
public partial class SetBinding : Window
{
    private string keyPressed;
    private bool save = false;

    public SetBinding()
    {

        InitializeComponent();

        KeyboardManager.KeyPressed += (sender, key) =>
        {
            this.Dispatcher.Invoke(() => { Apply(key); }); ;
        };
        KeyboardManager.StartListeningForKeyPress();

    }

    private void Apply(string key)
    {
        keyPressed = key;
        save = true;
        this.Close();
    }

    private void buttonCancel_Click(object sender, RoutedEventArgs e)
    {
        save = false;
        this.Close();
    }

    public bool Save() {  return save; }
    public string KeyPressed() { return keyPressed; }
}
