using System;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public event Action PlayerStepped;

    private List<PlatformModificator> _mods;

    public void StepOn()
    {
        PlayerStepped?.Invoke();
    }

    public void Modificate(PlatformModificator modificator)
    {
        if(_mods == null)
        {
            _mods = new List<PlatformModificator>();
        }
        foreach (var mod in _mods)
        {
            if (mod.GetType() == modificator.GetType())
            {
                return;
            }
        }
        _mods.Add(modificator);
        modificator.Init();
        Debug.Log(_mods.Count);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }


    private void Update()
    {
        //Tests Only
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Modificate(new MovingPlatform(this));
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Modificate(new DisappearingPlatform(this));
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StepOn();
        }
        _mods?.ForEach(mod => mod.OnUpdate());
    }

    private void FixedUpdate()
    {
        _mods?.ForEach(mod => mod.OnFixedUpdate());
    }

    private void OnDestroy()
    {
        _mods?.ForEach(mod => mod.OnDestroy());
    }
}
