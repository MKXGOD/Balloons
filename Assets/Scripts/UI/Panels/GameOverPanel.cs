using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private LeaderboardPanel _leaderboardPanel;

    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextMeshProUGUI _recordScore;

    private float _currentScore;
    private void Awake()
    {
        Close();
    }
    private string CurrentName()
    {
        if (_inputField.text == "")
            return "noname";
        else return _inputField.text;
    }
    public void EndGame(float amount)
    {
        _currentScore = amount;
        _recordScore.text = "Твой счет: " + amount.ToString();

        Time.timeScale = 0;

        Open();
    }
    public void Open()
    { 
       gameObject.SetActive(true);
    }
    public void Close()
    { 
        gameObject.SetActive(false);
    }
    public void SaveData()
    {
        Close();
        _leaderboardPanel.SetData(CurrentName(), _currentScore);
        _leaderboardPanel.gameObject.SetActive(true);

    }
}
