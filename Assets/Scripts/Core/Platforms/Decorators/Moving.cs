using UnityEngine;

public class Moving : PlatformDecorator, IPausable
{
    private float _speed;
    private bool _movementOver;
    private Vector2 _movementDestination;
    private Movement _movement;
    private const float _nearRange = 0.5f;

    private bool _isPaused = false;
    public Moving(Platform platform) : base(platform)
    {
    }

    public override void Init()
    {
        _speed = UnityEngine.Random.Range(1f, 5f);
        _movement = new Movement(Platform.transform, _speed);
        _movementDestination = GetRandomDestination();
        _movementOver = false;
        GameContext.Instance.Runtime.GamePause.Register(this);
    }

    public override void FixedUpdate()
    {
        if (_isPaused) return;
        Move();
        Decorator?.FixedUpdate();
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
        var x = UnityEngine.Random.Range(CameraBounds.Min.x, CameraBounds.Max.x);
        var y = Platform.transform.position.y;
        return new Vector2(x, y);
    }

    private bool NearDestination()
    {
        if ((_movementDestination - (Vector2)Platform.transform.position).magnitude <= _nearRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Pause()
    {
        _isPaused = true;
    }

    public void UnPause()
    {
        _isPaused = false;
    }
}
