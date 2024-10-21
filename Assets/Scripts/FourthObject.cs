using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthObject : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    void Update()
    {
        Vector3 newPosition = transform.position + transform.forward * _moveSpeed;
        Vector3 newRotation = transform.rotation.eulerAngles + Vector3.up * _rotationSpeed;
 
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(newRotation);
        
    }
}
