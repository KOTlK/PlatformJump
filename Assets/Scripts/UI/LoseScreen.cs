using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour, IWindow
{
    [SerializeField] private Text _currentScore;
    [SerializeField] private Text _bestScore;
    [SerializeField] private Button _restart;

    private Score Score => GameContext.Instance.Score;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void UpdateView()
    {
        _currentScore.text = $"Your score: {Score.GetCurrentScore()}";
        _bestScore.text = $"Best score: {Score.TryLoadHighScore()}";
    }

    private void RestartGame()
    {
        GameContext.Instance.Restart();
    }

    private void Awake()
    {
        _restart.onClick.AddListener(RestartGame);
        GameContext.Instance.Runtime.GameEnded += UpdateView;
    }

    private void OnDestroy()
    {
        _restart.onClick.RemoveListener(RestartGame);
        GameContext.Instance.Runtime.GameEnded -= UpdateView;
    }

    
}

