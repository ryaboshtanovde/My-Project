using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private Vector3 _moveDirection = Vector3.zero;

    void FixedUpdate()
    {
        transform.position += _moveDirection * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        _moveDirection = direction;
    }
}
