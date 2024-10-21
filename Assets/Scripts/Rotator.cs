using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        Vector3 newRotation = transform.rotation.eulerAngles + Vector3.up * _rotationSpeed;
        transform.rotation = Quaternion.Euler(newRotation);
    }
}
