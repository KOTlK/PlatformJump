using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private PlatformSpawnChances _spawnChances;
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private Transform _platformParent;

    private Core _core;
    private GameContext _gameContext;

    private void Awake()
    {
        _gameContext = new GameContext();
        var player = _gameContext.ResourceManager.InstantiateResource<Player>("player");
        var lowerBorder = _gameContext.ResourceManager.InstantiateResource<LowerBorder>("lowerborder");

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
