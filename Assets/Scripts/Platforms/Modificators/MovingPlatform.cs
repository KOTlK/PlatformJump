﻿using UnityEngine;

public class MovingPlatform : PlatformModificator
{
    private float _speed;
    private bool _movementOver;
    private Vector2 _movementDestination;
    private Movement _movement;
    private const float _nearRange = 0.5f;

    public MovingPlatform(Platform platform) : base(platform)
    {
    }

    public override void Init()
    {
        _speed = UnityEngine.Random.Range(1f, 5f);
        _movement = new Movement(BindedPlatform.transform, _speed);
        _movementDestination = GetRandomDestination();
        _movementOver = false;
    }

    public override void OnFixedUpdate()
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
        var y = BindedPlatform.transform.position.y;
        return new Vector2(x, y);
    }

    private bool NearDestination()
    {
        if((_movementDestination - (Vector2)BindedPlatform.transform.position).magnitude <= _nearRange)
        {
            return true;
        } else
        {
            return false;
        }
    }

    
}