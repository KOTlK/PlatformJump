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
        FirstTouchAwaiter.Touched -= TurnOffUI;
    }
}
