using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private LeaderboardRowUI _rowUIPrefab;
    [SerializeField] private ScoreManager ScoreManager;

    public void DrawList()
    {
        var scores = ScoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(_rowUIPrefab, transform).GetComponent<LeaderboardRowUI>();
            row.SetRowValue(i+1, scores[i].Name, scores[i].Score);
        }

    }
}
