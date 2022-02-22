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


}
