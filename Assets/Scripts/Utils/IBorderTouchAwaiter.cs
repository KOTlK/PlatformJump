using System;
using UnityEngine;
public interface IBorderTouchAwaiter
{
    event Action<BorderSide> BorderTouched;
    void WaitTouch(Vector2 position);
}
