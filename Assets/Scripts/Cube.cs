using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class Cube : MonoBehaviour
{
    public float divisionChanche { get; private set; } = 1f;
    public Rigidbody rigidBody { get; private set; }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        transform.localScale = Vector3.one;
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    public void SetDivisionChanche(float chanche)
    {
        divisionChanche = chanche;
    }

    public void ChangeScale(Vector3 ChangeScale)
    {
        transform.localScale = ChangeScale;
    }

    public float GetExplosionModifier()
    {
        return 1 / transform.localScale.x;
    }
}