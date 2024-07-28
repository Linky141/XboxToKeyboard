using SharpDX.XInput;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace XboxToKeyboard.Utils
{
    [Flags]
    public enum ExtendedGamepadButtonFlags
    {
        None = 0,
        DPadUp = GamepadButtonFlags.DPadUp,
        DPadDown = GamepadButtonFlags.DPadDown,
        DPadLeft = GamepadButtonFlags.DPadLeft,
        DPadRight = GamepadButtonFlags.DPadRight,
        Start = GamepadButtonFlags.Start,
        Back = GamepadButtonFlags.Back,
        LeftThumb = GamepadButtonFlags.LeftThumb,
        RightThumb = GamepadButtonFlags.RightThumb,
        LeftShoulder = GamepadButtonFlags.LeftShoulder,
        RightShoulder = GamepadButtonFlags.RightShoulder,
        A = GamepadButtonFlags.A,
        B = GamepadButtonFlags.B,
        X = GamepadButtonFlags.X,
        Y = GamepadButtonFlags.Y,


        LeftTrigger = 1 << 16,
        RightTrigger = 1 << 17,
        LeftThumbstickUp = 1 << 18,
        LeftThumbstickDown = 1 << 19,
        LeftThumbstickLeft = 1 << 20,
        LeftThumbstickRight = 1 << 21,
        RightThumbstickUp = 1 << 22,
        RightThumbstickDown = 1 << 23,
        RightThumbstickLeft = 1 << 24,
        RightThumbstickRight = 1 << 25
    }

    public class GamepadManager
    {
        private Controller controller;
        private State previousState;
        private State currentState;
        private CancellationTokenSource cts;
        private readonly ConnectionStatusManager connectionStatusManager;
        private Dispatcher dispatcher;
        private ConsoleManager consoleManager;

 
        private const byte TriggerThreshold = 30; 
        private const short StickThreshold = 5000;

        public event EventHandler<ExtendedGamepadButtonFlags> ButtonDown;
        public event EventHandler<ExtendedGamepadButtonFlags> ButtonUp;

        public GamepadManager(ConnectionStatusManager connectionStatusManager, ConsoleManager consoleManager, Dispatcher dispatcher)
        {
            this.connectionStatusManager = connectionStatusManager;
            this.consoleManager = consoleManager;
            this.dispatcher = dispatcher;

            controller = new Controller(UserIndex.One);
            if (!controller.IsConnected)
            {
                this.connectionStatusManager.Disconnected();
            }
            else
            {
                this.connectionStatusManager.Connected();
                previousState = controller.GetState();
                cts = new CancellationTokenSource();
            }
        }

        public bool ConnectController()
        {
            controller = new Controller(UserIndex.One);
            if (!controller.IsConnected)
            {
                this.connectionStatusManager.Disconnected();
                this.consoleManager.Add("ERROR: Can not connect to gamepad");
                return false;
            }
            else
            {
                this.connectionStatusManager.Connected();
                previousState = controller.GetState();
                cts = new CancellationTokenSource();
                this.consoleManager.Add("Gamepad connected");
                return true;
            }
        }

        public async Task StartAsync()
        {
            await Task.Run(() => Update(cts.Token), cts.Token);
        }

        public void Stop()
        {
            cts.Cancel();
        }

        private void Update(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    currentState = controller.GetState();

           
                    foreach (GamepadButtonFlags button in Enum.GetValues(typeof(GamepadButtonFlags)))
                    {
                        if (button == GamepadButtonFlags.None) continue;

                        bool wasPressed = (previousState.Gamepad.Buttons & button) != 0;
                        bool isPressed = (currentState.Gamepad.Buttons & button) != 0;

                        if (!wasPressed && isPressed)
                        {
                            OnButtonDown((ExtendedGamepadButtonFlags)button);
                        }
                        else if (wasPressed && !isPressed)
                        {
                            OnButtonUp((ExtendedGamepadButtonFlags)button);
                        }
                    }

            
                    bool wasLeftTriggerPressed = previousState.Gamepad.LeftTrigger > TriggerThreshold;
                    bool isLeftTriggerPressed = currentState.Gamepad.LeftTrigger > TriggerThreshold;

                    if (!wasLeftTriggerPressed && isLeftTriggerPressed)
                    {
                        OnButtonDown(ExtendedGamepadButtonFlags.LeftTrigger);
                    }
                    else if (wasLeftTriggerPressed && !isLeftTriggerPressed)
                    {
                        OnButtonUp(ExtendedGamepadButtonFlags.LeftTrigger);
                    }

                    bool wasRightTriggerPressed = previousState.Gamepad.RightTrigger > TriggerThreshold;
                    bool isRightTriggerPressed = currentState.Gamepad.RightTrigger > TriggerThreshold;

                    if (!wasRightTriggerPressed && isRightTriggerPressed)
                    {
                        OnButtonDown(ExtendedGamepadButtonFlags.RightTrigger);
                    }
                    else if (wasRightTriggerPressed && !isRightTriggerPressed)
                    {
                        OnButtonUp(ExtendedGamepadButtonFlags.RightTrigger);
                    }

              
                    CheckThumbstick(
                        previousState.Gamepad.LeftThumbX,
                        previousState.Gamepad.LeftThumbY,
                        currentState.Gamepad.LeftThumbX,
                        currentState.Gamepad.LeftThumbY,
                        ExtendedGamepadButtonFlags.LeftThumbstickUp,
                        ExtendedGamepadButtonFlags.LeftThumbstickDown,
                        ExtendedGamepadButtonFlags.LeftThumbstickLeft,
                        ExtendedGamepadButtonFlags.LeftThumbstickRight);

                    CheckThumbstick(
                        previousState.Gamepad.RightThumbX,
                        previousState.Gamepad.RightThumbY,
                        currentState.Gamepad.RightThumbX,
                        currentState.Gamepad.RightThumbY,
                        ExtendedGamepadButtonFlags.RightThumbstickUp,
                        ExtendedGamepadButtonFlags.RightThumbstickDown,
                        ExtendedGamepadButtonFlags.RightThumbstickLeft,
                        ExtendedGamepadButtonFlags.RightThumbstickRight);

                    previousState = currentState;
                    Thread.Sleep(10); 
                }
            }
            catch (Exception ex)
            {
                Stop();
                this.dispatcher.Invoke(() => { connectionStatusManager.Disconnected(); });
                this.dispatcher.Invoke(() => { this.consoleManager.Add("Gamepad disconnected"); });
            }
        }

        private void CheckThumbstick(short prevX, short prevY, short currX, short currY,
            ExtendedGamepadButtonFlags up, ExtendedGamepadButtonFlags down,
            ExtendedGamepadButtonFlags left, ExtendedGamepadButtonFlags right)
        {
            bool wasUp = prevY > StickThreshold;
            bool isUp = currY > StickThreshold;
            bool wasDown = prevY < -StickThreshold;
            bool isDown = currY < -StickThreshold;
            bool wasLeft = prevX < -StickThreshold;
            bool isLeft = currX < -StickThreshold;
            bool wasRight = prevX > StickThreshold;
            bool isRight = currX > StickThreshold;

            if (!wasUp && isUp)
            {
                OnButtonDown(up);
            }
            else if (wasUp && !isUp)
            {
                OnButtonUp(up);
            }

            if (!wasDown && isDown)
            {
                OnButtonDown(down);
            }
            else if (wasDown && !isDown)
            {
                OnButtonUp(down);
            }

            if (!wasLeft && isLeft)
            {
                OnButtonDown(left);
            }
            else if (wasLeft && !isLeft)
            {
                OnButtonUp(left);
            }

            if (!wasRight && isRight)
            {
                OnButtonDown(right);
            }
            else if (wasRight && !isRight)
            {
                OnButtonUp(right);
            }
        }

        protected virtual void OnButtonDown(ExtendedGamepadButtonFlags button)
        {
            ButtonDown?.Invoke(this, button);
        }

        protected virtual void OnButtonUp(ExtendedGamepadButtonFlags button)
        {
            ButtonUp?.Invoke(this, button);
        }
    }
}
