using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondObject : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    void Update()
    {
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.up * _rotationSpeed);
        transform.rotation = newRotation;
    }
}
