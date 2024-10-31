using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explodingForce;

    public float DivisionChanche { get; private set; } = 1f;

    private void Start()
    {
        Renderer _renderer = GetComponent<Renderer>();
        _renderer.material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    public void SetDivisionChanche(float chanche)
    {
        DivisionChanche = chanche;
    }
}
