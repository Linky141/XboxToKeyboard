using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using XboxToKeyboard;

public static class KeyboardManager
{
    public static event EventHandler<string> KeyPressed;

    [StructLayout(LayoutKind.Sequential)]
    private struct INPUT
    {
        public uint type;
        public InputUnion u;
    }

    [StructLayout(LayoutKind.Explicit)]
    private struct InputUnion
    {
        [FieldOffset(0)]
        public MOUSEINPUT mi;
        [FieldOffset(0)]
        public KEYBDINPUT ki;
        [FieldOffset(0)]
        public HARDWAREINPUT hi;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct KEYBDINPUT
    {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct HARDWAREINPUT
    {
        public uint uMsg;
        public ushort wParamL;
        public ushort wParamH;
    }

    private const uint INPUT_MOUSE = 0;
    private const uint INPUT_KEYBOARD = 1;
    private const uint INPUT_HARDWARE = 2;

    private const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
    private const uint KEYEVENTF_KEYUP = 0x0002;
    private const uint KEYEVENTF_SCANCODE = 0x0008;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

    [DllImport("user32.dll")]
    private static extern short GetAsyncKeyState(int vKey);

    private static ushort VkKeyScan(char ch)
    {
        return (ushort)NativeMethods.VkKeyScan(ch);
    }

    private static ushort MapVirtualKey(ushort wCode, uint uMapType)
    {
        return (ushort)NativeMethods.MapVirtualKey(wCode, uMapType);
    }

    private static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern short VkKeyScan(char ch);

        [DllImport("user32.dll")]
        public static extern uint MapVirtualKey(uint uCode, uint uMapType);
    }

    public static void SimulateKeyPress(ushort keyCode)
    {
        ushort scanCode = MapVirtualKey(keyCode, 0);

        INPUT[] inputs = new INPUT[1];

        inputs[0] = new INPUT
        {
            type = INPUT_KEYBOARD,
            u = new InputUnion
            {
                ki = new KEYBDINPUT
                {
                    wVk = keyCode,
                    wScan = scanCode,
                    dwFlags = KEYEVENTF_SCANCODE,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            }
        };

        SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
    }

    public static void SimulateKeyRelease(ushort keyCode)
    {
        ushort scanCode = MapVirtualKey(keyCode, 0);

        INPUT[] inputs = new INPUT[1];

        inputs[0] = new INPUT
        {
            type = INPUT_KEYBOARD,
            u = new InputUnion
            {
                ki = new KEYBDINPUT
                {
                    wVk = keyCode,
                    wScan = scanCode,
                    dwFlags = KEYEVENTF_SCANCODE | KEYEVENTF_KEYUP,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            }
        };

        SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
    }

    public static void StartListeningForKeyPress()
    {
        Task.Run(() =>
        {
            while (true)
            {
                foreach (var key in Keycodes.keyCodes)
                {
                    if (GetAsyncKeyState(key.Value) != 0)
                    {
                        KeyPressed?.Invoke(null, key.Key);
                    }
                }
                Thread.Sleep(10); // Adjust the delay as needed
            }
        });
    }
}
