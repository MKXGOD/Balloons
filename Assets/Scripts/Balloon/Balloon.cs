using System;
using TMPro;
using UnityEngine;

public class Balloon : MonoBehaviour, IDamageable
{
    [SerializeField] private TextMeshProUGUI _healthText;

    private int _healthPoint;
    private int _maxHealthPoint;

    private SpriteRenderer _spriteRenderer;

    private Color32[] _colors = new Color32[4] { new Color32(233, 79, 55, 255), new Color32(0, 191, 255, 255), new Color32(255, 250, 205, 255), new Color32(127, 255, 0, 255) };
  

    public static Action OnDie;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _maxHealthPoint = UnityEngine.Random.Range(1, 4);
        _healthPoint = _maxHealthPoint;

        SetColor();
        UpdateHealthUI();
    }
    private void SetColor()
    {
        _spriteRenderer.color = _colors[UnityEngine.Random.Range(0, 4)];
    }
    private void UpdateHealthUI()
    {
        _healthText.text = _healthPoint.ToString();
    }
    public void Damage(int value)
    {
        _healthPoint -= value;
        UpdateHealthUI();
        if (_healthPoint <= 0)
        {
            OnDie?.Invoke();
            Destroy(gameObject);

        }
    }
}
