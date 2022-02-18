public struct PlatformSpawnChances
{
    public static int GetChances(PlatformType type)
    {
        switch (type)
        {
            case PlatformType.Static:
                return 70;
            case PlatformType.Moving:
                return 40;
            case PlatformType.StaticDisappearing:
                return 25;
            case PlatformType.MovingDisappearing:
                return 15;
            default: return 0;
        }
    }
}
