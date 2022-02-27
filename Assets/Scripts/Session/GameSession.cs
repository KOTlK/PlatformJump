using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    private Core _core;
    private GameContext _gameContext;

    private Player _player;

    private bool _touched = false;
    private ResourceManager ResourceManager => _gameContext.ResourceManager;


    private void Awake()
    {
        _gameContext = new GameContext();
        _player = ResourceManager.InstantiateResource<Player>("player");
        var lowerBorder = ResourceManager.InstantiateResource<LowerBorder>("lowerborder");
        var spawnChances = ResourceManager.TryLoadResource<PlatformSpawnChances>("spawnchances");

        var coreInitialData = new CoreInitialData { LowerBorder = lowerBorder,
                                                 Player = _player,
                                                 SpawnChances = spawnChances };

        _core = new Core();
        _core.Init(coreInitialData);


        _gameContext.GamePause.Pause();
    }


    private void Update()
    {
        _core.Update();
        TryGetFirstTouch();
    }

    private void FixedUpdate()
    {
        _core.FixedUpdate();
    }

    private void OnDestroy()
    {
        _core.OnDestroy();
    }

    private void TryGetFirstTouch()
    {
        if (_touched) return;
        if (Input.GetMouseButtonUp(0))
        {
            _touched = true;
            _gameContext.GamePause.UnPause();
            _player.Jump();
        }
    }
}
