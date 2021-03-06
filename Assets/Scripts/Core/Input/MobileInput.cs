using System;
using UnityEngine;
public class MobileInput : IPlayerInput
{
    public event Action<float> HorizontalAxisChanged;
    public event Action ScreenTouched;

    public void UpdateInput()
    {
        Move();
        WaitForTouch();
    }

    private void Move()
    {
        var h = Input.acceleration.x;
        HorizontalAxisChanged?.Invoke(h);
    }

    private void WaitForTouch()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Ended) ScreenTouched?.Invoke();
        }
    }

}
