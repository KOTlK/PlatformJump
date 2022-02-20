using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _jumpVelocity;

    [Header("Every fixed update add this amount to player velocity.y")]
    [SerializeField] private float _fallVelocityMultiplier;

    private Rigidbody2D _body;
    private Collider2D _collider;
    private PlayerPhysics _physics;
    private BorderTeleporter _borderTeleporter;

    private float _fallVelocity = 0;


    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _physics = new PlayerPhysics(_body);
        _borderTeleporter = new BorderTeleporter(this);
    }


    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            Move(horizontal);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        _borderTeleporter.Update();
                
    }

    private void FixedUpdate()
    {
        UpdateCollider();
        ApplyFall();
    }

    private void OnDestroy()
    {
        _borderTeleporter.OnDestroy();
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

    private void Move(float direction)
    {
        _physics.SetVelocity(VelocityAxis.X, new Vector2(direction * _speed, 0));
    }

    private void ApplyFall()
    {
        _fallVelocity += _fallVelocityMultiplier;
        _physics.IncreaseVelocity(VelocityAxis.Y, _fallVelocity);
    }

}
