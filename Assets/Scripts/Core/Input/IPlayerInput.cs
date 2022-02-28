using System;

public interface IPlayerInput
{
    public event Action<float> HorizontalAxisChanged;
    public event Action ScreenTouched;
    public event Action DebugButtonPressed;
    public void UpdateInput();
}
