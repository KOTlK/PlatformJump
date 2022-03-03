using Extensions;
using UnityEngine;

public class CameraBounds
{
    private static Camera _camera;

    public CameraBounds(Camera camera)
    {
        _camera = camera;
    }

    public static Vector2 Max
    {
        get { return _camera.GetMaxBounds();}
    }

    public static Vector2 Min
    {
        get { return _camera.GetMinBounds();}
    }
}
