using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour, IWindow
{
    [SerializeField] private Text _score;

    private void ChangeScore(int score)
    {
        _score.text = $"{score}";
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        GameContext.Instance.Score.ScoreChanged += ChangeScore;
    }

    private void OnDestroy()
    {
        GameContext.Instance.Score.ScoreChanged += ChangeScore;
    }
}
