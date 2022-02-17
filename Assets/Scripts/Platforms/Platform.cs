using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public event Action PlayerStepped;

    private PlatformModificator _modificator;

    public void Init()
    {
        _modificator.Init();
    }

    public void Modify(PlatformModificator modificator)
    {
        _modificator = modificator;
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
        _modificator.FixedUpdate();
    }

    private void OnDestroy()
    {
        _modificator.Destroy();
    }

}
