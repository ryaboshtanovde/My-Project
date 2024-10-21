using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdObject : MonoBehaviour
{
    [SerializeField] private float _growSpeed;

    void Update()
    {
        Vector3 newScale = transform.localScale + Vector3.one * _growSpeed;
        transform.localScale = newScale;
    }
}
