using TMPro;
using UnityEngine;

public class BankUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private BankSystem _bank;

    public void SetBankSystem(BankSystem bank)
    { 
        _bank = bank;
        _bank.OnScoreChange += OnScoreChanged;
    }
    private void OnScoreChanged()
    {
        _scoreText.text = _bank.CurrentScore.ToString();
    }
}
