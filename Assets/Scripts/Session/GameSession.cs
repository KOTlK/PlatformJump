using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private LowerBorder _lowerBorderPrefab;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private PlatformSpawnChances _spawnChances;
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private Transform _platformParent;

    private Core _core;

    private void Awake()
    {
        var player = Instantiate(_playerPrefab);
        var lowerBorder = Instantiate(_lowerBorderPrefab);
        var coreInitialData = new CoreInitialData { LowerBorder = lowerBorder, 
                                                 PlatformParent = _platformParent, 
                                                 PlatformPrefab = _platformPrefab,
                                                 Player = player,
                                                 SpawnChances = _spawnChances };

        _core = new Core();
        _core.Init(coreInitialData);
    }


    private void Update()
    {
        _core.Update();
    }

    private void FixedUpdate()
    {
        _core.FixedUpdate();
    }

    private void OnDestroy()
    {
        _core.OnDestroy();
    }


}
