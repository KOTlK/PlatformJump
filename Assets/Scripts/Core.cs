using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private Transform _platformParent;

    private PlatformLifeCycle _platformLifeCycle;

    private void Awake()
    {
        _platformLifeCycle = new PlatformLifeCycle(_platformPrefab, _platformParent);
        _platformLifeCycle.StartSpawning();
        _platformLifeCycle.SpawnStartPlatforms(10);
    }

    private void OnDestroy()
    {
        _platformLifeCycle.StopSpawning();
    }

    private void Update()
    {
        _platformLifeCycle.Update();
    }


}
