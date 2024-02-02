using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardPanel : MonoBehaviour
{
    private ScoreUI _scoreUI;
    private void Awake()
    {
        _scoreUI = GetComponentInChildren<ScoreUI>();
        Close();
    }
    public void SetData(string name, float score)
    {
        _scoreUI.SaveData(name, score);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
