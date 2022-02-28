using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LowerBorder : MonoBehaviour
{
    public event Action<Platform> PlatformTouched;
    public event Action<Player> PlayerTouched;

    private void Awake()
    {
        var collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Platform>(out Platform platform))
        {
            PlatformTouched?.Invoke(platform);
        }

        if(collision.TryGetComponent<Player>(out Player player))
        {
            PlayerTouched?.Invoke(player);
        }
    }
}
