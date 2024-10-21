using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        Vector3 newPosition = transform.position + transform.forward * _moveSpeed;
        transform.position = newPosition;
    }
}
