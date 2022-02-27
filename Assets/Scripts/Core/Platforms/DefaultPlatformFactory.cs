using UnityEngine;

public class DefaultPlatformFactory : IPlatformFactory
{
    private Transform _parent;

    private ResourceManager ResourceManager => GameContext.Instance.ResourceManager;


    public Platform Spawn()
    {
        if (_parent == null)
        {
            _parent = ResourceManager.InstantiateResource<Transform>("platforms");
        }

        var obj = ResourceManager.InstantiateResource<Platform>("platform", _parent);

        return obj;
    }
}
