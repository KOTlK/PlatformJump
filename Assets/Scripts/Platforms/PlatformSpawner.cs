using System;

public class PlatformSpawner
{
    public event Action<Platform> PlatformSpawned;


    public Platform Spawn(IPlatformFactory factory, PlatformType type, PlatformDestroyer destroyer)
    {
        var platform = factory.Spawn();
        DecoratePlatform(type, platform, destroyer);
        PlatformSpawned?.Invoke(platform);
        return platform;
    }


    private void DecoratePlatform(PlatformType type, Platform platform, PlatformDestroyer destroyer)
    {
        switch (type)
        {
            case PlatformType.Moving:
                platform.Decorate(new Moving(platform));
                return;
            case PlatformType.MovingDisappearing:
                platform.Decorate(new Moving(platform)).Decorate(new Disappearing(platform, destroyer));
                return;
            case PlatformType.StaticDisappearing:
                platform.Decorate(new Disappearing(platform, destroyer));
                return;
            case PlatformType.Static:
                return;
            default: throw new Exception($"No decorator type such {type}");
        }

    }

}
