using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Score
{
    public event Action<int> ScoreChanged;

    private int _score = 0;

    private const string ScoreKey = "Score";

    public Score()
    {
        GameContext.Instance.Runtime.GameEnded += SaveHighScore;
    }

    public int GetCurrentScore()
    {
        return _score;
    }

    public int TryLoadHighScore()
    {
        SaveHighScore();
        return PlayerPrefs.GetInt(ScoreKey);
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    private void SaveHighScore()
    {
        if (PlayerPrefs.HasKey(ScoreKey) == false) PlayerPrefs.SetInt(ScoreKey, _score);
        if (PlayerPrefs.GetInt(ScoreKey) < _score) PlayerPrefs.SetInt(ScoreKey, _score);
    }
}
