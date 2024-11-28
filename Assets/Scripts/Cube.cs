using System;
using UnityEngine;

[RequireComponent (typeof(MeshFilter))]
[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(BoxCollider))]
[RequireComponent (typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private bool _isGrounded = false;
    public event Action<Cube> TouchGround;

    private Color _startedColor = Color.white;
    private Color _groundedColor = Color.cyan;

    private void OnCollisionEnter(Collision collision)
    {
        if (_isGrounded == false)
            if (collision.transform.TryGetComponent(out Ground ground))
            {
                TouchGround?.Invoke(this);
                _isGrounded = true;
                GetComponent<Renderer>().material.color = _groundedColor;
            }
    }

    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = _startedColor;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        _isGrounded = false;
    }
}
