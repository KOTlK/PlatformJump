using UnityEngine;

public class DefaultPlatformFactory : IPlatformFactory
{
    private readonly Platform _prefab;
    private readonly Transform _parent;

    public DefaultPlatformFactory(Platform prefab, Transform parent)
    {
        _prefab = prefab;
        _parent = parent;
    }

    public Platform Spawn()
    {
        var obj = MonoBehaviour.Instantiate(_prefab, _parent);
        return obj;
    }
}
