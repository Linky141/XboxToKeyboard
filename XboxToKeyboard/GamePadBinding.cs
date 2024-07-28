namespace XboxToKeyboard;

public class GamePadBinding
{
    public string LeftTrigger { get; set; }
    public string RightTrigger { get; set; }
    public string LeftBumper { get; set; }
    public string RightBumper{ get; set; }
    public string RightAnalogUp { get; set; }
    public string RightAnalogDown { get; set; }
    public string RightAnalogRight { get; set; }
    public string RightAnalogLeft { get; set; }
    public string RightAnalog { get; set; }
    public string LeftAnalogUp { get; set; }
    public string LeftAnalogDown { get; set; }
    public string LeftAnalogRight { get; set; }
    public string LeftAnalogLeft { get; set; }
    public string LeftAnalog { get; set; }
    public string DpadUp { get; set; }
    public string DpadDown { get; set; }
    public string DpadRight { get; set; }
    public string DpadLeft { get; set; }
    public string X { get; set; }
    public string Y { get; set; }
    public string A { get; set; }
    public string B { get; set; }
    public string Select { get; set; }
    public string Start { get; set; }

    public override string? ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"LeftTrigger: {LeftTrigger}");
        sb.AppendLine($"RightTrigger: {RightTrigger}");
        sb.AppendLine($"LeftBumper: {LeftBumper}");
        sb.AppendLine($"RightBumper: {RightBumper}");
        sb.AppendLine($"RightAnalogUp: {RightAnalogUp}");
        sb.AppendLine($"RightAnalogDown: {RightAnalogDown}");
        sb.AppendLine($"RightAnalogRight: {RightAnalogRight}");
        sb.AppendLine($"RightAnalogLeft: {RightAnalogLeft}");
        sb.AppendLine($"RightAnalog: {RightAnalog}");
        sb.AppendLine($"LeftAnalogUp: {LeftAnalogUp}");
        sb.AppendLine($"LeftAnalogDown: {LeftAnalogDown}");
        sb.AppendLine($"LeftAnalogRight: {LeftAnalogRight}");
        sb.AppendLine($"LeftAnalogLeft: {LeftAnalogLeft}");
        sb.AppendLine($"LeftAnalog: {LeftAnalog}");
        sb.AppendLine($"DpadUp: {DpadUp}");
        sb.AppendLine($"DpadDown: {DpadDown}");
        sb.AppendLine($"DpadRight: {DpadRight}");
        sb.AppendLine($"DpadLeft: {DpadLeft}");
        sb.AppendLine($"X: {X}");
        sb.AppendLine($"Y: {Y}");
        sb.AppendLine($"A: {A}");
        sb.AppendLine($"B: {B}");
        sb.AppendLine($"Select: {Select}");
        sb.AppendLine($"Start: {Start}");
        return sb.ToString();
    }
}
