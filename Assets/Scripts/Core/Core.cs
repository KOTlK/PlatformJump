public class Core
{
    private PlatformLifeCycle _platformLifeCycle;
    private GameCamera _gameCamera;
    private LowerBorderTouchAwaiter _lowerBorderTouchAwaiter;
    private BorderTeleporter _borderTeleporter;
    private PlayerDeath _playerDeath;



    public void Init(CoreInitialData initialData)
    {
        _lowerBorderTouchAwaiter = new LowerBorderTouchAwaiter(initialData.LowerBorder);
        _platformLifeCycle = new PlatformLifeCycle(_lowerBorderTouchAwaiter, initialData.SpawnChances);
        _platformLifeCycle.StartSpawning();
        _platformLifeCycle.SpawnStartPlatforms(10);
        _gameCamera = new GameCamera(initialData.Player.transform);
        _borderTeleporter = new BorderTeleporter(initialData.Player);
        _playerDeath = new PlayerDeath(initialData.LowerBorder);
    }


    public void Update()
    {
        _platformLifeCycle.Update();
        _borderTeleporter.Update();
    }

    public void FixedUpdate()
    {
        _gameCamera.FixedUpdate();
    }

}


public struct CoreInitialData
{
    public LowerBorder LowerBorder;
    public PlatformSpawnChances SpawnChances;
    public Player Player;
}
