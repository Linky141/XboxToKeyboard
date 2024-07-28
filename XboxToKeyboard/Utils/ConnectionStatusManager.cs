using System.Windows.Controls;

namespace XboxToKeyboard.Utils;

public class ConnectionStatusManager
{
    private readonly Label indicator;
    private bool connectionStatus;
    private readonly Button connectButton;

    public ConnectionStatusManager(Label indicator, Button connectButton)
    {
        this.indicator = indicator;
        this.connectButton = connectButton;
        connectionStatus = false;
    }



    public void Connected()
    {
        connectButton.IsEnabled = false;
        indicator.Content = "Connected";
        connectionStatus = true;
    }

    public void Disconnected()
    {
        connectButton.IsEnabled = true;
        indicator.Content = "Disconnected";
        connectionStatus = false;
    }

    public bool IsConnected() { return connectionStatus; }
}
