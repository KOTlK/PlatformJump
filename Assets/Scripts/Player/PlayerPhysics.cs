using UnityEngine;
using System;

public class PlayerPhysics
{
    private readonly Rigidbody2D _playerBody;


    public PlayerPhysics(Rigidbody2D rigidbody)
    {
        _playerBody = rigidbody;
    }

    public Vector2 Velocity => _playerBody.velocity;

    public void SetVelocity(VelocityAxis axis, Vector2 velocity)
    {
        var playerVelocity = _playerBody.velocity;
        switch (axis)
        {
            case VelocityAxis.X:
                playerVelocity.x = velocity.x;
                _playerBody.velocity = playerVelocity;
                return;
            case VelocityAxis.Y:
                playerVelocity.y = velocity.y;
                _playerBody.velocity = playerVelocity;
                return;
            case VelocityAxis.Both:
                _playerBody.velocity = velocity;
                return;
            default: throw new Exception($"Can't find axis {axis}");
        }
    }
}


public enum VelocityAxis
{
    X,
    Y,
    Both,
}
