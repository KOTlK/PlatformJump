using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour, IPausable
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _jumpVelocity;

    [Header("Every fixed update add this amount to player velocity.y")]
    [SerializeField] private float _fallVelocityMultiplier;

    private Rigidbody2D _body;
    private Collider2D _collider;
    private PlayerPhysics _physics;

    private float _fallVelocity = 0;

    private IPlayerInput _playerInput => GameContext.Instance.PlayerInput;

    public void Move(float direction)
    {
        _physics.SetVelocity(VelocityAxis.X, new Vector2(direction * _speed, 0));
    }
    
    public void Pause()
    {
        _body.simulated = false;
    }

    public void UnPause()
    {
        _body.simulated = true;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void Jump()
    {
        _physics.SetVelocity(VelocityAxis.Y, _jumpVelocity);
        _fallVelocity = 0;
    }

    private void UpdateCollider()
    {
        if (_physics.Velocity.y > 0 && _collider.enabled == false) return;
        if (_physics.Velocity.y <= 0 && _collider.enabled) return;
        _collider.enabled = !_collider.enabled;
    }


    private void ApplyFall()
    {
        _fallVelocity += _fallVelocityMultiplier;
        _physics.IncreaseVelocity(VelocityAxis.Y, _fallVelocity);
    }

    private void Subscribe()
    {
        FirstTouchAwaiter.Touched += Jump;
        _playerInput.HorizontalAxisChanged += Move;
    }

    private void UnSubscribe()
    {
        FirstTouchAwaiter.Touched -= Jump;
        _playerInput.HorizontalAxisChanged -= Move;
    }

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _physics = new PlayerPhysics(_body);
        GameContext.Instance.Runtime.GamePause.Register(this);
        Subscribe();
    }

    private void FixedUpdate()
    {
        if (GameContext.Instance.Runtime.Status == SessionStatus.Paused) return;
        UpdateCollider();
        ApplyFall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_physics.Velocity.y > 0) return;
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform))
        {
            Jump();
            platform.StepOn();
        }

    }

    private void OnDisable()
    {
        UnSubscribe();
    }

    private void OnDestroy()
    {
        UnSubscribe();
    }
}
