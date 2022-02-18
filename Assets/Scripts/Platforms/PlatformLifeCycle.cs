using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLifeCycle
{
    private readonly PlatformSpawner _spawner;
    private readonly PlatformDestroyer _destroyer;
    private readonly LowerBorderTouchAwaiter _borderTouchAwaiter;
    private readonly List<Platform> _spawnedPlatforms;
    private readonly IPlatformFactory _platformFactory;

    private Vector2 _previousPosition;
    private bool _isSpawning;

    private const float SpawnDistance = 5f;

    public PlatformLifeCycle(Platform platformPrefab, Transform parent, LowerBorder lowerBorder)
    {
        _spawner = new PlatformSpawner();
        _destroyer = new PlatformDestroyer();
        _borderTouchAwaiter = new LowerBorderTouchAwaiter(lowerBorder);
        _spawnedPlatforms = new List<Platform>();
        _platformFactory = new DefaultPlatformFactory(platformPrefab, parent);
    }


    public void Update()
    {
        _borderTouchAwaiter.FixedUpdate();
    }

    public void Destroy()
    {
        _borderTouchAwaiter.Destroy();
    }

    public void SpawnStartPlatforms(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnRandomPlatform();
        }
    }

    public void StartSpawning()
    {
        if (_isSpawning) return;

        _borderTouchAwaiter.BorderTouched += _destroyer.DestroyPlatform;
        _destroyer.PlatformDestroyed += delegate { SpawnRandomPlatform(); };
        _destroyer.PlatformDestroyed += RemoveFromList;
        _isSpawning = true;
    }

    public void StopSpawning()
    {
        if (_isSpawning == false) return;

        _borderTouchAwaiter.BorderTouched -= _destroyer.DestroyPlatform;
        _destroyer.PlatformDestroyed -= delegate { SpawnRandomPlatform(); };
        _destroyer.PlatformDestroyed -= RemoveFromList;
        _isSpawning = false;
    }


    private void RemoveFromList(Platform platform)
    {
        _spawnedPlatforms.Remove(platform);
    }

    private void SpawnRandomPlatform()
    {
        var platform = _spawner.Spawn(_platformFactory, GetRandomTypeUsingChances(), _destroyer);
        var x = GetRandomXInScreenBorders();
        if (_previousPosition == Vector2.zero)
        {
            var y = CameraBounds.Min.y + 1f;
            var position = new Vector2(x, y);
            platform.transform.position = position;
            _previousPosition = position;
        } else
        {
            var y = _previousPosition.y + SpawnDistance;
            var position = new Vector2(x, y);
            platform.transform.position = position;
            _previousPosition = position;
        }

        _spawnedPlatforms.Add(platform);
        platform.Init();
    }

    private PlatformType GetRandomType()
    {
        var amount = Enum.GetValues(typeof(PlatformType)).Length;
        var random = UnityEngine.Random.Range(0, amount);
        return (PlatformType)random;
    }

    private PlatformType GetRandomTypeUsingChances()
    {
        var random = UnityEngine.Random.Range(0, 100);
        PlatformType type = GetRandomType();
        if (random == 0) return GetRandomTypeUsingChances();
        if (random <= PlatformSpawnChances.GetChances(type)) return type;
        return GetRandomTypeUsingChances();
    }

    private float GetRandomXInScreenBorders()
    {
        return UnityEngine.Random.Range(CameraBounds.Min.x, CameraBounds.Max.x);
    }

}
