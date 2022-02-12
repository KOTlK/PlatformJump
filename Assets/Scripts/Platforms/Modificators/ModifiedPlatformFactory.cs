using System;
public class ModifiedPlatformFactory
{
    public Platform Spawn(PlatformType type, IPlatformFactory factory)
    {
        var platform = factory.Spawn();
        platform.Init(GetModificator(type, platform));
        return platform;
    }

    private PlatformModificator GetModificator(PlatformType type, Platform platform)
    {
        switch (type)
        {
            case PlatformType.Moving:
                return new Moving(platform);
            case PlatformType.Static:
                return new Static(platform);
            case PlatformType.StaticDisappearing:
                return new StaticDisappearing(platform);
            case PlatformType.MovingDisappearing:
                return new MovingDisappearing(platform);
            default:
                throw new Exception($"Can't find type {type} in PlatformType");
        }
    }
}


public enum PlatformType
{
    Moving,
    Static,
    StaticDisappearing,
    MovingDisappearing,
}
