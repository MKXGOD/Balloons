using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData _scoreData;

    private void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{ }");
        _scoreData = JsonUtility.FromJson<ScoreData>(json);
    }
    public IEnumerable<ScoreItem> GetHighScores() 
    {
        return _scoreData.Scores.OrderByDescending(x => x.Score);
    }
    public void AddScore(ScoreItem score)
    {
        _scoreData.Scores.Add(score);
    }
    public void SaveScore()
    {
        var json = JsonUtility.ToJson(_scoreData);
        PlayerPrefs.SetString("scores", json);
    }
}

[Serializable]
public struct ScoreData
{
    public List<ScoreItem> Scores;
}

