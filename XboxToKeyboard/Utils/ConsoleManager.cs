using System.Windows.Controls;

namespace XboxToKeyboard.Utils;

public class ConsoleManager
{
    private readonly ListBox console;
    private readonly int consoleBuffer = 18;

    public ConsoleManager(ListBox console)
    {
        this.console = console;
    }

    public void Add(string text)
    {
        if (console.Items.Count >= consoleBuffer)
            console.Items.RemoveAt(0);

        console.Items.Add(text);
    }

    public void Clear()
    {
        console.Items.Clear();
    }
}
