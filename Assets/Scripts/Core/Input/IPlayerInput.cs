using System;

public interface IPlayerInput
{
    public event Action<float> HorizontalAxisChanged;
    public event Action ScreenTouched;
    public void UpdateInput();
}
