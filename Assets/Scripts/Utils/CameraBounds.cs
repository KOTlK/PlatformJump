using Extensions;
using UnityEngine;

public static class CameraBounds
{
    private static Camera _camera = Camera.main;
    public static Vector2 Max
    {
        get { return _camera.GetMaxBounds();}
    }

    public static Vector2 Min
    {
        get { return _camera.GetMinBounds();}
    }
}
