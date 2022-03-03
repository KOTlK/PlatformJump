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

    private SessionStatus _status => GameContext.Instance.Runtime.Status;

    private float _speed
    {
        get
        {
            if (_target.position.y < (_camera.GetMaxBounds().y - _maxTargetDistanceFromUpperBorder)) return _defaultMovementSpeed;
            var distance = (_target.position - _camera.transform.position).sqrMagnitude;
            return _defaultMovementSpeed + distance / 50;
        }
    }

    public void FixedUpdate()
    {
        if (_status == SessionStatus.Paused) return;
        MoveUp();
    }

    private void MoveUp()
    {
        _camera.transform.position += new Vector3(0, _speed * Time.deltaTime);
    }

}
