using Extensions;
using UnityEngine;

public static class CameraBounds
{
    public static Vector2 MaxBounds
    {
        get { return Camera.main.GetMaxBounds();}
    }

    public static Vector2 MinBounds
    {
        get { return Camera.main.GetMinBounds();}
    }
}
