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
}
