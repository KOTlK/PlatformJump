using UnityEngine;

public class Core
{
    private PlatformLifeCycle _platformLifeCycle;
    private GameCamera _gameCamera;
    private LowerBorderTouchAwaiter _lowerBorderTouchAwaiter;
    private PlayerInput _playerInput;


    public void Init(CoreInitialData initialData)
    {
        _lowerBorderTouchAwaiter = new LowerBorderTouchAwaiter(initialData.LowerBorder);
        _platformLifeCycle = new PlatformLifeCycle(initialData.PlatformPrefab, initialData.PlatformParent, _lowerBorderTouchAwaiter, initialData.SpawnChances);
        _platformLifeCycle.StartSpawning();
        _platformLifeCycle.SpawnStartPlatforms(10);
        _gameCamera = new GameCamera(initialData.Player.transform);
        _playerInput = new PlayerInput(initialData.Player);
        _playerInput.Init(DeviceDetection.GetInput());
    }

    public void OnDestroy()
    {
        _platformLifeCycle.StopSpawning();
        _platformLifeCycle.Destroy();
    }


    public void Update()
    {
        _platformLifeCycle.Update();
        _playerInput.Update();
    }

    public void FixedUpdate()
    {
        _gameCamera.FixedUpdate();
    }



}


public struct CoreInitialData
{
    public Platform PlatformPrefab;
    public Transform PlatformParent;
    public LowerBorder LowerBorder;
    public PlatformSpawnChances SpawnChances;
    public Player Player;
}
