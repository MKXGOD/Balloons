using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI RowUI;
    public ScoreManager ScoreManager;

    public void SaveData(string name, float score)
    {
        ScoreManager.AddScore(new ScoreItem(name, score));

        var scores = ScoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(RowUI, transform).GetComponent<RowUI>();
            row.Rank.text = (i + 1).ToString();
            row.Name.text = scores[i].Name;
            row.Score.text = scores[i].Score.ToString();
        }

    }
}
