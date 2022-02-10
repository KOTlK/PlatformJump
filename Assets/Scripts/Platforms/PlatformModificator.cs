public abstract class PlatformModificator
{
    protected Platform BindedPlatform;

    public PlatformModificator(Platform platform)
    {
        BindedPlatform = platform;
    }

    public virtual void Init() { }

    public virtual void OnUpdate() { }

    public virtual void OnFixedUpdate() { }

    public virtual void OnDestroy() { }
}
