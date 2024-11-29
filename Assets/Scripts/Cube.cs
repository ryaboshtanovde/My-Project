using System;
using UnityEngine;

[RequireComponent (typeof(MeshFilter))]
[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(BoxCollider))]
[RequireComponent (typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private bool _isGrounded = false;
    private Renderer _renderer;
    private Rigidbody _rigidbody;
    private Color _startedColor = Color.white;
    private Color _groundedColor = Color.cyan;

    public event Action<Cube> TouchGround;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isGrounded == false)
            if (collision.transform.TryGetComponent(out Ground ground))
            {
                TouchGround?.Invoke(this);
                _isGrounded = true;
                _renderer.material.color = _groundedColor;
            }
    }

    private void OnEnable()
    {
        _renderer.material.color = _startedColor;
        _rigidbody.velocity = Vector3.zero;
        _isGrounded = false;
    }
}
