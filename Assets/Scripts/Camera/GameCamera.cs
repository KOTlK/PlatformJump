using UnityEngine;
using Extensions;

public class GameCamera
{
    private readonly Transform _target;
    private readonly Camera _camera = Camera.main;

    private float _defaultMovementSpeed = 4f;
    private float _maxTargetDistanceFromUpperBorder;


    public GameCamera(Transform target)
    {
        _target = target;
        _maxTargetDistanceFromUpperBorder = (_camera.GetMaxBounds().y - _camera.GetMinBounds().y) / 4;
    }

    public void FixedUpdate()
    {
        MoveUp();
    }

    private void MoveUp()
    {
        _camera.transform.position += new Vector3(0, GetSpeed() * Time.deltaTime);
    }

    private float GetSpeed()
    {
        if (_target.position.y < (_camera.GetMaxBounds().y - _maxTargetDistanceFromUpperBorder)) return _defaultMovementSpeed;
        var distance = (_target.position - _camera.transform.position).sqrMagnitude;
        return _defaultMovementSpeed + distance / 50;

    }

}
