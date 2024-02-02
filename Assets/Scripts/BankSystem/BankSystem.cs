public class BankSystem
{
    public delegate void ScoreHandler();
    public event ScoreHandler OnScoreChange;
    public float CurrentScore { get; private set; }

    public void AddScore()
    {
        CurrentScore++;
        OnScoreChange?.Invoke();
    }
}
