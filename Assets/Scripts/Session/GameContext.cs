using UnityEngine;

public class GameContext : MonoBehaviour
{
    public static GameContext Instance { get; private set; }

    private ResourceManager _resourceManager;
    private IPlayerInput _playerInput;
    private UI _ui;
    private Runtime _runtime;
    private Score _score;

    public UI UI => _ui;
    public ResourceManager ResourceManager => _resourceManager;
    public Runtime Runtime => _runtime;
    public IPlayerInput PlayerInput => _playerInput;
    public Score Score => _score;

    public void Restart()
    {
        _runtime.Restart();
    }

    public void Init()
    {
        _runtime = new Runtime();
        _resourceManager = new ResourceManager();
        _playerInput = DeviceDetection.InputType;
        _score = new Score();
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
