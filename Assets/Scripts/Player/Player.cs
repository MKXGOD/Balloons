using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BankUI _bankUI;
    [SerializeField] private UIController _panelController;
    [SerializeField] private TextMeshProUGUI _healthText;

    private BankSystem _bankSystem;

    private int _health = 5;
    private void Awake()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        Balloon.OnDie += OnBalloonDied;
        Shreder.OnBalloonMissed += OnBalloonMissed;

        InitBankSystem();
        UpdateHealthUI();
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
        UpdateHealthUI();
        if (_health <= 0)
            Died();
    }
    private void Died()
    {
        Time.timeScale = 0;

        _panelController.OpenGameOverUI(_bankSystem);
        Destroy(gameObject);
    }
    private void UpdateHealthUI()
    {
        _healthText.text = _health.ToString();
    }
    private void OnDestroy()
    {
        Balloon.OnDie -= OnBalloonDied;
        Shreder.OnBalloonMissed -= OnBalloonMissed;
    }
}
