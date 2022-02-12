using UnityEngine;

public struct PhysicsSettings
{
    public Vector2 Gravity { get; set; }
}

public class PlayerPhysics
{
    private readonly PhysicsSettings _settings;
    private readonly Transform _targetBody;

    private Vector2 _velocity;

    public PlayerPhysics(PhysicsSettings settings, Transform target)
    {
        _settings = settings;
        _targetBody = target;
    }

    public Vector2 Velocity => _velocity;

    public void ApplyPhysics(float timeDelta)
    {
        _velocity += _settings.Gravity * timeDelta;
        var position = (Vector2)_targetBody.position;
        position += _velocity;
        _targetBody.position = position;
    }

    public void ApplyVelocityY(float amount)
    {
        var velocity = _velocity;
        velocity.y = amount;
        _velocity = velocity;
    }



}
