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
    [SerializeField] private LowerBorder _lowerBorder;
    [SerializeField] private PlatformSpawnChances _spawnChances;
    [SerializeField] private Player _player;


    private PlatformLifeCycle _platformLifeCycle;
    private GameCamera _gameCamera;
    private LowerBorderTouchAwaiter _lowerBorderTouchAwaiter;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _lowerBorderTouchAwaiter = new LowerBorderTouchAwaiter(_lowerBorder);
        _platformLifeCycle = new PlatformLifeCycle(_platformPrefab, _platformParent, _lowerBorderTouchAwaiter, _spawnChances);
        _platformLifeCycle.StartSpawning();
        _platformLifeCycle.SpawnStartPlatforms(10);
        _gameCamera = new GameCamera(_player.transform);
        _playerInput = new PlayerInput(_player);
        _playerInput.Init(new KeyboardInput());
    }

    private void OnDestroy()
    {
        _platformLifeCycle.StopSpawning();
        _platformLifeCycle.Destroy();
    }


    private void Update()
    {
        _platformLifeCycle.Update();
        _playerInput.Update();
    }

    private void FixedUpdate()
    {
        _gameCamera.FixedUpdate();
    }



}
