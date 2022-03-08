using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesDataStorage : IResourcesDataStorage
{
    [Serializable]
    private struct Resource
    {
        public string Path;
        public string Name;
    }

    private readonly Dictionary<string, string> _resources;

    public ResourcesDataStorage()
    {
        _resources = LoadResources();
    }

    public string TryGetPath(string name)
    {
        var lowercase = name.ToLower();
        if (_resources.ContainsKey(lowercase) == false) throw new Exception($"Can't find resource named {lowercase}");
        return _resources[lowercase];
    }


    private Dictionary<string, string> LoadResources()
    {
        Dictionary<string, string> resources = new Dictionary<string, string>();

        var textAsset = Resources.Load<TextAsset>("Text/ResourcePaths");

        var text = textAsset.text.Split(new string[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
        
        foreach (var line in text)
        {
            if (string.IsNullOrEmpty(line)) continue;

            var resource = JsonUtility.FromJson<Resource>(line);
            resources.Add(resource.Name.ToLower(), resource.Path);
        }
        return resources;
    }
}


