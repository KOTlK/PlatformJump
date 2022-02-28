using System;

public class FirstTouchAwaiter
{
    public static event Action Touched;

    public void Init()
    {
        GameContext.Instance.PlayerInput.ScreenTouched += Touch;
    }

    private void Touch()
    {
        Touched?.Invoke();
        GameContext.Instance.PlayerInput.ScreenTouched -= Touch;
    }
}
