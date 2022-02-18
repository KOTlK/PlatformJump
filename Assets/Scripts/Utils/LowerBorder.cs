using System;
using UnityEngine;

public class LowerBorder : MonoBehaviour
{
    public event Action<Platform> BorderTouched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Platform>(out Platform platform))
        {
            BorderTouched?.Invoke(platform);
        }
    }
}
