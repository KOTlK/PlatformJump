using System;

public class PlatformSpawner
{
    public event Action<Platform> PlatformSpawned;


    public Platform Spawn(IPlatformFactory factory, PlatformType type, PlatformDestroyer destroyer)
    {
        var platform = factory.Spawn();
        platform.Modify(GetModificatorByType(type, platform, destroyer));
        PlatformSpawned?.Invoke(platform);
        return platform;
    }


    private PlatformModificator GetModificatorByType(PlatformType type, Platform platform, PlatformDestroyer destroyer)
    {
        switch (type)
        {
            case PlatformType.Moving:
                return new Moving(platform);
            case PlatformType.Static:
                return new Static(platform);
            case PlatformType.StaticDisappearing:
                return new StaticDisappearing(platform, destroyer);
            case PlatformType.MovingDisappearing:
                return new MovingDisappearing(platform, destroyer);
            default: throw new Exception($"No modificator type such {type}");
        }
    }

}
