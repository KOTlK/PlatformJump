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
    private ResourceManager ResourceManager => _gameContext.ResourceManager;

    private void Awake()
    {
        _gameContext = new GameContext();
        var player = ResourceManager.InstantiateResource<Player>("player");
        var lowerBorder = ResourceManager.InstantiateResource<LowerBorder>("lowerborder");
        var spawnChances = ResourceManager.TryLoadResource<PlatformSpawnChances>("spawnchances");

        var coreInitialData = new CoreInitialData { LowerBorder = lowerBorder,
                                                 Player = player,
                                                 SpawnChances = spawnChances };

        _core = new Core();
        _core.Init(coreInitialData);
    }


    private void Update()
    {
        _core.Update();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _gameContext.GamePause.Pause();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _gameContext.GamePause.UnPause();
        }
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
