using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public event Action PlayerStepped;

    private PlatformModificator _modificator;

    public void Init(PlatformModificator modificator)
    {
        _modificator = modificator;
        _modificator.Init();
    }

    public void StepOn()
    {
        PlayerStepped?.Invoke();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        //Tests Only
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StepOn();
        }
    }

    private void FixedUpdate()
    {
        _modificator.FixedUpdate();
    }

    private void OnDestroy()
    {
        _modificator.Destroy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (player.Physics.Velocity.y <= 0)
            {
                PlayerStepped?.Invoke();
                player.StepOnPlatform();
            }
        }
    }
}
