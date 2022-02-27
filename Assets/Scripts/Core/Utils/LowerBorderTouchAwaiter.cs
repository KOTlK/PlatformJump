using System;
using UnityEngine;

public class LowerBorderTouchAwaiter
{
    public event Action<Platform> BorderTouched;
    private LowerBorder _border;
    private Camera _camera = Camera.main;

    public LowerBorderTouchAwaiter(LowerBorder border)
    {
        _border = border;
        ApplyBorderScale();
        _border.BorderTouched += InvokeTouch;
    }

    public void FixedUpdate()
    {
        ApplyBorderPosition();
    }

    public void Destroy()
    {
        _border.BorderTouched -= InvokeTouch;
    }

    private void ApplyBorderScale()
    {
        var scale = _border.transform.lossyScale;
        scale.x = CameraBounds.Max.x + 10;
        _border.transform.localScale = scale;
    }

    private void ApplyBorderPosition()
    {
        var x = _camera.transform.position.x;
        var y = CameraBounds.Min.y - 1;
        var position = new Vector2(x, y);
        _border.transform.position = position;
    }

    private void InvokeTouch(Platform platform)
    {
        BorderTouched?.Invoke(platform);
    }

}
