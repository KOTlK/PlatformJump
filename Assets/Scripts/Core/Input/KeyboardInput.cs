using System;
using UnityEngine;

public class KeyboardInput : IPlayerInput
{
    public event Action<float> HorizontalAxisChanged;
    public event Action DebugButtonPressed;
    public event Action ScreenTouched;

    public void UpdateInput()
    {
        MovePlayer();
        DebugAction();
        WaitForTouch();
    }

    private void MovePlayer()
    {
        var h = Input.GetAxis("Horizontal");
        HorizontalAxisChanged?.Invoke(h);
    }

    private void WaitForTouch()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ScreenTouched?.Invoke();
        }
    }

    private void DebugAction()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DebugButtonPressed?.Invoke();
        }
    }
}
