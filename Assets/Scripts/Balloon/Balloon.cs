using System;
using TMPro;
using UnityEngine;

public class Balloon : MonoBehaviour, IDamageable
{
    [SerializeField] private TextMeshProUGUI _healthText;

    private int _healthPoint;
    private int _maxHealthPoint;

    private SpriteRenderer _spriteRenderer;

    private Color[] _colors = new Color[4] { Color.red, Color.blue, Color.yellow, Color.green};
  

    public static Action OnDie;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _spriteRenderer.color = _colors[UnityEngine.Random.Range(0, 4)];
        _maxHealthPoint = UnityEngine.Random.Range(1, 4);
        _healthPoint = _maxHealthPoint;
        UpdateHealthUI();
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
