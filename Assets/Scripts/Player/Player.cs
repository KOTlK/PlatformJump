using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Vector2 _gravity;
    private Movement _movement;
    private PlayerPhysics _physics;
    private BorderTeleporter _borderTeleporter;

    public PlayerPhysics Physics => _physics;

    private void Awake()
    {
        _movement = new Movement(transform, _speed);
        var physicsSettings = new PhysicsSettings { Gravity = _gravity };
        _physics = new PlayerPhysics(physicsSettings, transform);
        _borderTeleporter = new BorderTeleporter(this);
    }

    public void StepOnPlatform()
    {
        _physics.ApplyVelocityY(_jumpForce);
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            _movement.MoveHorizontal(horizontal);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _physics.ApplyVelocityY(_jumpForce);
        }

        _borderTeleporter.Update();
        
    }

    private void FixedUpdate()
    {
        _physics.ApplyPhysics(Time.deltaTime);
    }

    private void OnDestroy()
    {
        _borderTeleporter.OnDestroy();
    }
}
