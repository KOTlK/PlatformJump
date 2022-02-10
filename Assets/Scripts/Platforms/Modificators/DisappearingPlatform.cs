public class DisappearingPlatform : PlatformModificator
{
    public DisappearingPlatform(Platform platform) : base(platform)
    {
    }

    public override void Init()
    {
        BindedPlatform.PlayerStepped += DestroySelf;
    }

    public override void OnDestroy()
    {
        BindedPlatform.PlayerStepped -= DestroySelf;
    }

    private void DestroySelf()
    {
        BindedPlatform.Destroy();
    }
}
