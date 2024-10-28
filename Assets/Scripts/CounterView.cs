using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _displayNumber;

    private void OnEnable()
    {
        _counter.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _counter.Changed -= OnChanged;
    }

    private void OnChanged(int count)
    {
        _displayNumber.text = count.ToString();
    }
}