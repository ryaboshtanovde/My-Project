using System;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent (typeof(MeshFilter))]
[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(BoxCollider))]
[RequireComponent (typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    bool _isGrounded = false;
    public event Action<Cube> TouchGround;

    private void OnCollisionEnter(Collision collision)
    {
        if (_isGrounded == false)
            if (collision.transform.TryGetComponent(out Ground ground))
            {
                TouchGround?.Invoke(this);
                _isGrounded = true;
            }
    }

    private void OnEnable()
    {

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        _isGrounded = false;
    }
}
