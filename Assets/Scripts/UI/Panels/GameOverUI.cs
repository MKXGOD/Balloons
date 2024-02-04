using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextMeshProUGUI _currentScore;

    private ScoreManager _scoreManager;
    private LeaderboardUI _leaderboardPanel;
    private BankSystem _bankSystem;
  
    private void UpdateUI()
    { 
        _currentScore.text = _bankSystem.CurrentScore.ToString();
    }
    private string CurrentName()
    {
        if (_inputField.text == "")
            return "Noname";
        else return _inputField.text;
    }
    private float CurrentScore()
    { 
        return _bankSystem.CurrentScore;
    }
    private void SaveData()
    {
        _scoreManager.AddScore(new ScoreItem(CurrentName(), CurrentScore()));
        _scoreManager.SaveScore();
    }
    public void Open(BankSystem bankSystem, ScoreManager scoreManager, LeaderboardUI leaderboard)
    {
        _scoreManager = scoreManager;
        _bankSystem = bankSystem;
        _leaderboardPanel = leaderboard;

        UpdateUI();

        gameObject.SetActive(true);
    }
    public void Close()
    {
        SaveData();
        _leaderboardPanel.Open();

        gameObject.SetActive(false);
       
    }


}
