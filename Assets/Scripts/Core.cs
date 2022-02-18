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

    private PlatformLifeCycle _platformLifeCycle;
    private Camera _camera;
    private LowerBorderTouchAwaiter _lowerBorderTouchAwaiter;

    private void Awake()
    {
        _lowerBorderTouchAwaiter = new LowerBorderTouchAwaiter(_lowerBorder);
        _platformLifeCycle = new PlatformLifeCycle(_platformPrefab, _platformParent, _lowerBorderTouchAwaiter, _spawnChances);
        _platformLifeCycle.StartSpawning();
        _platformLifeCycle.SpawnStartPlatforms(10);
        _camera = Camera.main;
    }

    private void OnDestroy()
    {
        _platformLifeCycle.StopSpawning();
        _platformLifeCycle.Destroy();
    }


    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        MoveCamera(new Vector2(horizontal, vertical));
        _platformLifeCycle.Update();
    }

    //Debug only
    private void MoveCamera(Vector2 direction)
    {
        _camera.transform.position += (Vector3)direction * 5 * Time.deltaTime;
    }


}
