using UnityEngine;

public class Movement
{
    private readonly Transform _transform;
    private readonly float _speed;

    public Movement(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;
    }

    public void MoveTo(Vector2 position)
    {
        Vector2 prevPosition = _transform.position;
        Vector2 nextPositionDelta = (position - prevPosition).normalized * _speed * Time.deltaTime;
        prevPosition += nextPositionDelta;
        _transform.position = prevPosition;

    }

    public void MoveHorizontal(float direction)
    {
        Vector2 position = _transform.position;
        var deltaX = position.x + (direction * _speed * Time.deltaTime);
        position.x = deltaX;
        _transform.position = position;
    }

}
