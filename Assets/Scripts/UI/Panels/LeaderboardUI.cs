using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private ScoreUI _scoreUI;

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Open()
    {
        _scoreUI.DrawList();
        gameObject.SetActive(true);
    }
    public void Close()
    {
        RestartGame();

        gameObject.SetActive(false);
    }
}
