using System;
using UnityEngine;

public class BorderTouchAwaiter : IBorderTouchAwaiter
{
    public event Action<BorderSide> BorderTouched;

    private const float BorderOffset = 2f;

    public void WaitTouch(Vector2 position)
    {
        if (position.x >= CameraBounds.Max.x + BorderOffset)
        {
            BorderTouched?.Invoke(BorderSide.Right);
        }
        if (position.x <= CameraBounds.Min.x - BorderOffset)
        {
            BorderTouched?.Invoke(BorderSide.Left);
        }
    }
}
