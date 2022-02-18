using System;

public class PlatformDestroyer
{
    public event Action<Platform> PlatformDestroyed;

    public void DestroyPlatform(Platform platform)
    {
        platform.Destroy();
        PlatformDestroyed?.Invoke(platform);
    }
}
