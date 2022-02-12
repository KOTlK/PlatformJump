public class MovingDisappearing : Moving
{
    private readonly StaticDisappearing _disappearing;

    public MovingDisappearing(Platform platform) : base(platform)
    {
        _disappearing = new StaticDisappearing(platform);
    }

    public override void Init()
    {
        base.Init();
        _disappearing.Init();
    }

    public override void Destroy()
    {
        base.Destroy();
        _disappearing.Destroy();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
