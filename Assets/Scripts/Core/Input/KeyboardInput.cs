using System;
using UnityEngine;

public class KeyboardInput : IPlayerInput
{
    public event Action<float> HorizontalAxisChanged;
    public event Action DebugButtonPressed;

    public void UpdateInput()
    {
        MovePlayer();
        DebugAction();
    }

    private void MovePlayer()
    {
        var h = Input.GetAxis("Horizontal");
        HorizontalAxisChanged?.Invoke(h);
    }

    private void DebugAction()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DebugButtonPressed?.Invoke();
        }
    }
}
