using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public event Action PlayerStepped;

    public void StepOn()
    {
        PlayerStepped?.Invoke();
    }

}
