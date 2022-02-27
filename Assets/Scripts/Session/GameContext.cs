using System;

public class GameContext
{
    public static GameContext Instance { get; private set; }

    private readonly ResourceManager _resourceManager;
    private readonly GamePause _gamePause;

    public ResourceManager ResourceManager => _resourceManager;
    public GamePause GamePause => _gamePause;

    public GameContext()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            throw new Exception($"Can't be more than one object of type GameContext");
        }

        _resourceManager = new ResourceManager();
        _gamePause = new GamePause();
    }
}
