using System;

public interface IPlayerInput
{
    public event Action<float> HorizontalAxisChanged;
    public event Action DebugButtonPressed;
    public void UpdateInput();
}
