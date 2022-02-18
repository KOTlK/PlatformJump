public class Disappearing : PlatformDecorator
{
    private readonly PlatformDestroyer _destroyer;
    public Disappearing(Platform platform, PlatformDestroyer destroyer) : base(platform)
    {
        _destroyer = destroyer;
    }

    public override void Init()
    {
        Platform.PlayerStepped += DestroyPlatform;
    }

    public override void Destroy()
    {
        Platform.PlayerStepped -= DestroyPlatform;
    }

    private void DestroyPlatform()
    {
        _destroyer.DestroyPlatform(Platform);
    }
}
