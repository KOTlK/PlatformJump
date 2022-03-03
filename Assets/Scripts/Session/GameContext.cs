using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameContext : MonoBehaviour
{
    public static GameContext Instance { get; private set; }

    private ResourceManager _resourceManager;
    private IPlayerInput _playerInput;
    private UI _ui;
    private Runtime _runtime;

    public UI UI => _ui;
    public ResourceManager ResourceManager => _resourceManager;
    public Runtime Runtime => _runtime;
    public IPlayerInput PlayerInput => _playerInput;

    public void Restart()
    {
        _runtime.Restart();
        SceneManager.LoadScene(0);
    }

    public void Init()
    {
        _runtime = new Runtime();
        _resourceManager = new ResourceManager();
        _playerInput = DeviceDetection.InputType;
        _ui = new UI();

    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);

        }


        
    }
}
