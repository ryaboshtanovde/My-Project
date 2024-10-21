using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increaser : MonoBehaviour
{
    [SerializeField] private float _increaseSpeed;

    private void Update()
    {
        Vector3 newScale = transform.localScale + Vector3.one * _increaseSpeed;
        transform.localScale = newScale;
    }
}
