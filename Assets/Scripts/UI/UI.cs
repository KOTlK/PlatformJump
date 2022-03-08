using UnityEngine;

public class UI
{
    private Canvas _ui;
    private IWindow _loseScreen;
    private IWindow _gameUI;

    public UI()
    {
        _gameUI = GameContext.Instance.ResourceManager.InstantiateResource<InGameUI>("ingameui");
        _loseScreen = GameContext.Instance.ResourceManager.InstantiateResource<LoseScreen>("losescreen");
        _loseScreen.Hide();
        _gameUI.Show();
        GameContext.Instance.Runtime.GameEnded += _loseScreen.Show;
    }

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
