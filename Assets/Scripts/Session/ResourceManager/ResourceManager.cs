using UnityEngine;

public class ResourceManager
{
    private readonly IResourcesDataStorage _dataStorage;

    public ResourceManager()
    {
        _dataStorage = new ResourcesDataStorage();
    }

    public T TryLoadResource<T>(string name)
        where T : UnityEngine.Object
    {
        var path = _dataStorage.TryGetPath(name);
        return Resources.Load(path) as T;
    }

    public T InstantiateResource<T>(string name)
    {
        var resource = TryLoadResource<GameObject>(name);
        var component = MonoBehaviour.Instantiate(resource).GetComponent<T>();
        return component;
    }

    public T InstantiateResource<T>(string name, Transform parent)
    {
        var resource = TryLoadResource<GameObject>(name);
        var component = MonoBehaviour.Instantiate(resource, parent).GetComponent<T>();
        return component;
    }
}




