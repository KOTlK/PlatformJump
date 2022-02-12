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

    private IPlatformFactory _platformFactory;
    private ModifiedPlatformFactory _modifiedPlatformFactory;

    private void Awake()
    {
        _platformFactory = new DefaultPlatformFactory(_platformPrefab, _platformParent);
        _modifiedPlatformFactory = new ModifiedPlatformFactory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _modifiedPlatformFactory.Spawn(PlatformType.Moving, _platformFactory);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _modifiedPlatformFactory.Spawn(PlatformType.Static, _platformFactory);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _modifiedPlatformFactory.Spawn(PlatformType.StaticDisappearing, _platformFactory);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _modifiedPlatformFactory.Spawn(PlatformType.MovingDisappearing, _platformFactory);
        }
    }


}
