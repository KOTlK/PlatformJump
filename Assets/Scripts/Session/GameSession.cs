using UnityEngine;

public class GameSession : MonoBehaviour
{
    private Core _core;
    private CameraBounds _cameraBounds;

    private Player _player;
    private FirstTouchAwaiter _firstTouchAwaiter;


    private ResourceManager ResourceManager => GameContext.Instance.ResourceManager;
    private GameContext GameContext => GameContext.Instance;

    private void Start()
    {
        GameContext.Init();
        Init();
        GameContext.Instance.Runtime.Pause();
    }

    private void Init()
    {
        _cameraBounds = new CameraBounds(Camera.main);

        _firstTouchAwaiter = new FirstTouchAwaiter();
        _firstTouchAwaiter.Init();

        LoadCore();

        GameContext.UI.ShowStartUI();

        PlayerDeath.Died += GameContext.Runtime.Pause;
        PlayerDeath.Died += ShowDeathUI;
        FirstTouchAwaiter.Touched += GameContext.Runtime.UnPause;

    }


    private void LoadCore()
    {
        _player = ResourceManager.InstantiateResource<Player>("player");
        var lowerBorder = ResourceManager.InstantiateResource<LowerBorder>("lowerborder");
        var spawnChances = ResourceManager.TryLoadResource<PlatformSpawnChances>("spawnchances");

        var coreInitialData = new CoreInitialData
        {
            LowerBorder = lowerBorder,
            Player = _player,
            SpawnChances = spawnChances
        };

        _core = new Core();
        _core.Init(coreInitialData);
    }

    private void Update()
    {
        _core.Update();
        GameContext.PlayerInput.UpdateInput();
    }

    private void FixedUpdate()
    {
        _core.FixedUpdate();
    }


    private void ShowDeathUI()
    {
        var ui = GameContext.ResourceManager.InstantiateResource<LoseScreen>("losescreen");
        ui.UpdateView(new LoseScreenData { BestScore = 100, Score = 100 });
    }
}
