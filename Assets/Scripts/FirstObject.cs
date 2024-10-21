using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstObject : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;

    void Update()
    {
        Vector3 newPosition = transform.position + Vector3.forward * _movingSpeed;
        transform.position = newPosition;
    }
}
