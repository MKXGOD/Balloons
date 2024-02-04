using TMPro;
using UnityEngine;

public class RowUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _rank;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _score;
    public void SetRowValue(int rank, string name, float score)
    {
        _rank.text = rank.ToString();
        _name.text = name;
        _score.text = score.ToString();
    }
}
