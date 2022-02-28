using UnityEngine;

public static class DeviceDetection
{
    public static IPlayerInput InputType
    {
        get
        {
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    return new MobileInput();
                case RuntimePlatform.WindowsEditor:
                    return new KeyboardInput();
                case RuntimePlatform.WindowsPlayer:
                    return new KeyboardInput();
                default: return new KeyboardInput();
            }
        }
    }

}
