using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]

public class Cube : MonoBehaviour
{
    public float DivisionChanche { get; private set; } = 1f;

    private void Awake()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = GetRandomColor();
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
