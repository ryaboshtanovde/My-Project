using System;
using UnityEngine;

[RequireComponent (typeof(MeshFilter))]
[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(BoxCollider))]
[RequireComponent (typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public event Action<Cube> TouchGround;
    bool isGrounded = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (isGrounded == false)
            if (collision.transform.TryGetComponent(out Ground ground))
            {
                TouchGround?.Invoke(this);
                isGrounded = true;
            }
    }

    private void OnEnable()
    {
        isGrounded = false;
    }
}
