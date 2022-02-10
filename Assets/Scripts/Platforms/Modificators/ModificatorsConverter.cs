using System;

public class ModificatorsConverter
{
    public PlatformModificator GetNew(PlatformType type, Platform platform)
    {
        switch (type)
        {
            case PlatformType.Disappearing:
                return new DisappearingPlatform(platform);
            case PlatformType.Moving:
                return new MovingPlatform(platform);
            default: throw new Exception($"Cannot find PlatformType of {type}");
        }
    }
}


public enum PlatformType
{
    Disappearing,
    Moving,
}
