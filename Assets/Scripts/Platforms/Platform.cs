using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public event Action PlayerStepped;

    private PlatformDecorator _decorator;

    public void Init()
    {
        _decorator?.Init();
    }

    public Platform Decorate(PlatformDecorator modificator)
    {
        if (_decorator == null)
        {
            _decorator = modificator;
            return this;
        } else
        {
            _decorator.Decorate(modificator);
            return this;
        }
        
    }

    public void StepOn()
    {
        PlayerStepped?.Invoke();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }


    private void FixedUpdate()
    {
        _decorator?.FixedUpdate();
    }

    private void OnDestroy()
    {
        _decorator?.Destroy();
    }

}
