using System.Collections;
using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _countingTime;

    private int _count = 0;
    private Coroutine _coroutine;
    public event Action<int> Changed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(Counting());
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator Counting()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_countingTime);

        while (enabled)
        {
            _count++;
            Changed.Invoke(_count);
            yield return waitForSeconds;
        }
    }
}
