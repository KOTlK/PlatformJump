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
    private FirstTouchAwaiter _firstTouchAwaiter;
    private UI _ui;
    private ResourceManager ResourceManager => _gameContext.ResourceManager;


    private void Awake()
    {
        _gameContext = new GameContext();
        _player = ResourceManager.InstantiateResource<Player>("player");
        var lowerBorder = ResourceManager.InstantiateResource<LowerBorder>("lowerborder");
        var spawnChances = ResourceManager.TryLoadResource<PlatformSpawnChances>("spawnchances");

        _firstTouchAwaiter = new FirstTouchAwaiter();
        _firstTouchAwaiter.Init();

        var coreInitialData = new CoreInitialData { LowerBorder = lowerBorder,
                                                 Player = _player,
                                                 SpawnChances = spawnChances };

        _core = new Core();
        _core.Init(coreInitialData);

        

        _ui = new UI();
        _ui.ShowStartUI();

        PlayerDeath.Died += _gameContext.GamePause.Pause;
        PlayerDeath.Died += ShowDeathUI;
        FirstTouchAwaiter.Touched += _gameContext.GamePause.UnPause;

        _gameContext.GamePause.Pause();

    }


    private void Update()
    {
        _core.Update();
        _gameContext.PlayerInput.UpdateInput();
    }

    private void FixedUpdate()
    {
        _core.FixedUpdate();
    }

    private void OnDestroy()
    {
        _core.OnDestroy();
        PlayerDeath.Died -= _gameContext.GamePause.Pause;
        PlayerDeath.Died -= ShowDeathUI;
        FirstTouchAwaiter.Touched -= _gameContext.GamePause.UnPause;
    }

    private void ShowDeathUI()
    {
        var ui = _gameContext.ResourceManager.InstantiateResource<LoseScreen>("losescreen");
        ui.UpdateView(new LoseScreenData { BestScore = 100, Score = 100 });
    }
}
