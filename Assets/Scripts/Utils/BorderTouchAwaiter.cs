using System;
using UnityEngine;

public class BorderTouchAwaiter : IBorderTouchAwaiter
{
    public event Action<BorderSide> BorderTouched;

    private const float BorderOffset = 2f;

    public void WaitTouch(Vector2 position)
    {
        if (position.x >= CameraBounds.MaxBounds.x + BorderOffset)
        {
            BorderTouched?.Invoke(BorderSide.Right);
        }
        if (position.x <= CameraBounds.MinBounds.x - BorderOffset)
        {
            BorderTouched?.Invoke(BorderSide.Left);
        }
    }
}
