using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MovingPlatform : Platform
{
    private float _speed;
    private bool _movementOver;
    private Vector2 _movementDestination;
    private Movement _movement;
    private const float _nearRange = 0.5f;

    private void Start()
    {
        _speed = UnityEngine.Random.Range(1f, 5f);
        _movement = new Movement(transform, _speed);
        _movementDestination = GetRandomDestination();
        _movementOver = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_movementOver)
        {
            _movementDestination = GetRandomDestination();
        }
        _movement.MoveTo(_movementDestination);
        if (NearDestination())
        {
            _movementOver = true;
        }
        else
        {
            _movementOver = false;
        }
    }

    private Vector2 GetRandomDestination()
    {
        var x = UnityEngine.Random.Range(CameraBounds.MinBounds.x, CameraBounds.MaxBounds.x);
        var y = transform.position.y;
        return new Vector2(x, y);
    }

    private bool NearDestination()
    {
        if((_movementDestination - (Vector2)transform.position).magnitude <= _nearRange)
        {
            return true;
        } else
        {
            return false;
        }
    }

    
}
