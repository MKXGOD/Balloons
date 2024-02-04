using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;

    [SerializeField] private GameOverUI _gameOverUI;
    [SerializeField] private LeaderboardUI _leaderboardUI;

    public void OpenGameOverUI(BankSystem bank)
    {
        _gameOverUI.Open(bank, _scoreManager, _leaderboardUI);
    }
    public void CloseGameOverUI()
    {
        _gameOverUI.Close();
    }
    public void CloseLeaderboardUI()
    { 
        _leaderboardUI.Close();
    }
}
