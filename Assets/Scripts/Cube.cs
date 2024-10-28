using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explodingForce;

    private void Start()
    {
        Rigidbody _rigidbody = GetComponent<Rigidbody>();
        RandomDerectionForce(_rigidbody);

        Renderer _renderer = GetComponent<Renderer>();
        _renderer.material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    private void RandomDerectionForce(Rigidbody rigidbody)
    {
        Vector3 forceVector = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)).normalized * _explodingForce;
        rigidbody.AddForce(forceVector);
    }
}
