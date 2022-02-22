using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LowerBorder : MonoBehaviour
{
    public event Action<Platform> BorderTouched;
    private void Awake()
    {
        var collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Platform>(out Platform platform))
        {
            BorderTouched?.Invoke(platform);
        }
    }
}
