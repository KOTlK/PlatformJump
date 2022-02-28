using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private Text _currentScore;
    [SerializeField] private Text _bestScore;
    [SerializeField] private Button _restart;

    public void UpdateView(LoseScreenData data)
    {
        _currentScore.text = $"Your score: {data.Score}";
        _bestScore.text = $"Best score: {data.BestScore}";
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0); // doesn't work will be replaced
    }

    private void Awake()
    {
        _restart.onClick.AddListener(RestartGame);
    }

    private void OnDestroy()
    {
        _restart.onClick.RemoveListener(RestartGame);
    }
}


public struct LoseScreenData
{
    public int Score;
    public int BestScore;
}
