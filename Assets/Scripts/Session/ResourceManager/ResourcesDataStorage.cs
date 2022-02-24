using System;
using System.Collections.Generic;
using System.IO;
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

        var file = File.ReadAllLines("D:/Unity/Projects/PlatformJump/Test.json");
        foreach (var line in file)
        {
            if (string.IsNullOrEmpty(line)) continue;

            var resource = JsonUtility.FromJson<Resource>(line);
            resources.Add(resource.Name.ToLower(), resource.Path);
        }
        return resources;
    }
}


