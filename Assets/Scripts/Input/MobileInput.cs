﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class MobileInput : IPlayerInput
{
    public event Action<float> HorizontalAxisChanged;
    public event Action DebugButtonPressed;

    public void UpdateInput()
    {
        Move();
        Debug();
    }

    private void Move()
    {
        var h = Input.acceleration.x;
        HorizontalAxisChanged?.Invoke(h);
    }

    private void Debug()
    {
        if (Input.touchCount > 0)
        {
            DebugButtonPressed?.Invoke();
        }
    }
}
