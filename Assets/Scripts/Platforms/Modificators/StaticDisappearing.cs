public class StaticDisappearing : PlatformModificator
{
    public StaticDisappearing(Platform platform) : base(platform)
    {
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
        Platform.Destroy();
    }
}
