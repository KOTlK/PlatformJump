using System;

public class GameContext
{
    public static GameContext Instance { get; private set; }

    private readonly ResourceManager _resourceManager;


    public ResourceManager ResourceManager => _resourceManager;

    public GameContext()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            throw new Exception($"Can't be more than 1 object of type GameContext");
        }

        _resourceManager = new ResourceManager();
    }
}
