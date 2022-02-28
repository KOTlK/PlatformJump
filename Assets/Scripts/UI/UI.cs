using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UI
{
    private Canvas _ui;
    public void ShowStartUI()
    {
        _ui = GameContext.Instance.ResourceManager.InstantiateResource<Canvas>("startui");
        FirstTouchAwaiter.Touched += TurnOffUI;
    }

    private void TurnOffUI()
    {
        _ui.gameObject.SetActive(false);
    }
}
