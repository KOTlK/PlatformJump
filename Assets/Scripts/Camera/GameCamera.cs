using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Extensions;

public class GameCamera
{
    private readonly Transform _target;
    private readonly Camera _camera = Camera.main;

    private float _movementSpeed = 2f;
    private float _maxTargetDistanceFromUpperBorder;

    public GameCamera(Transform target)
    {
        _target = target;
        _maxTargetDistanceFromUpperBorder = (_camera.GetMaxBounds().y - _camera.GetMinBounds().y) / 4;
    }

    public void FixedUpdate()
    {
        MoveUp();
        MoveToTarget();
    }

    private void MoveUp()
    {
        _camera.transform.position += new Vector3(0, _movementSpeed * Time.deltaTime);
    }

    private void MoveToTarget()
    {
        if (_target.position.y < (_camera.GetMaxBounds().y - _maxTargetDistanceFromUpperBorder)) return;
        var position = _camera.transform.position;
        position.y = _target.position.y;

        _camera.transform.position = Vector3.Lerp(_camera.transform.position, position, 0.02f);
    }
}
