public class StaticDisappearing : PlatformModificator
{
    private readonly PlatformDestroyer _destroyer;
    public StaticDisappearing(Platform platform, PlatformDestroyer destroyer) : base(platform)
    {
        _destroyer = destroyer;
    }

    public override void Init()
    {
        base.Init();
        Platform.PlayerStepped += DestroyPlatform;
    }

    public override void Destroy()
    {
        base.Destroy();
        Platform.PlayerStepped -= DestroyPlatform;
    }

    private void DestroyPlatform()
    {
        _destroyer.DestroyPlatform(Platform);
    }
}
