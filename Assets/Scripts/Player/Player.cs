using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BankUI _bankUI;
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _healthText;

    private BankSystem _bankSystem;

    private int _health = 5;
    private void Awake()
    {
        InitBankSystem();

        _healthText.text = _health.ToString();

        Balloon.OnDie += OnBalloonDied;
        Shreder.OnBalloonMissed += OnBalloonMissed;
    }
    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.touches[0].position), Vector2.zero);


            if (hit.collider != null && hit.collider.TryGetComponent(out IDamageable iDamageable))
                iDamageable.Damage(1);
        }
    }
    private void InitBankSystem()
    {
        _bankSystem = new BankSystem();
        _bankUI.SetBankSystem(_bankSystem);
    }
    private void OnBalloonDied()
    {
        _bankSystem.AddScore();
    }
    private void OnBalloonMissed()
    {
        _health--;
        _healthText.text = _health.ToString();
        if (_health <= 0)
        {
            _gameOverPanel.EndGame(_bankSystem.CurrentScore);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Balloon.OnDie -= OnBalloonDied;
        Shreder.OnBalloonMissed -= OnBalloonMissed;
    }
}
