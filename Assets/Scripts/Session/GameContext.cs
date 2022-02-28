using System;

public class GameContext
{
    public static GameContext Instance { get; private set; }

    private readonly ResourceManager _resourceManager;
    private readonly GamePause _gamePause;
    private IPlayerInput _playerInput;

    public ResourceManager ResourceManager => _resourceManager;
    public GamePause GamePause => _gamePause;
    public IPlayerInput PlayerInput => _playerInput;

    public GameContext()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _resourceManager = new ResourceManager();
        _gamePause = new GamePause();
        _playerInput = DeviceDetection.InputType;
    }
}
