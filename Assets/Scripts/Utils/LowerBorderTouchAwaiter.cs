using System;
using UnityEngine;

public class LowerBorderTouchAwaiter
{
    public event Action<Platform> BorderTouched;

    public void WaitTouch(Platform platform)
    {
        if (platform.transform.position.y <= CameraBounds.MinBounds.y)
        {
            BorderTouched?.Invoke(platform);
        }
    }
}
