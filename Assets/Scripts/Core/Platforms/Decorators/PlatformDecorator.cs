public abstract class PlatformDecorator
{
    protected Platform Platform;
    protected PlatformDecorator Decorator;
    public PlatformDecorator(Platform platform)
    {
        Platform = platform;
    }

    public void Decorate(PlatformDecorator decorator)
    {
        if(Decorator == null)
        {
            Decorator = decorator;
            Decorator.Init();
        }
        else
        {
            Decorator.Decorate(decorator);
        }
    }

    public virtual void Init() { }
    public virtual void Destroy()
    {
        Decorator?.Destroy();
    }
    public virtual void Update()
    {
        Decorator?.Update();
    }
    public virtual void FixedUpdate()
    {
        Decorator?.FixedUpdate();
    }
}
