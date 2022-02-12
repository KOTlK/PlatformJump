public abstract class PlatformModificator
{
    protected Platform Platform;
    public PlatformModificator(Platform platform)
    {
        Platform = platform;
    }
    public virtual void Init() { }
    public virtual void FixedUpdate() { }
    public virtual void Destroy() { }
}
