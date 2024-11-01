using UnityEngine;

public class CubeScatter: MonoBehaviour
{
    [SerializeField] private float _explodingForce = 10;

    public void ScatterAround(Cube[] objects, Cube epicenter)
    {
        foreach (Cube scatteringObject in objects)
        {
            if (scatteringObject.TryGetComponent(out Rigidbody rigidbody))
            {
                if (scatteringObject.transform.localPosition == epicenter.transform.localPosition)
                {
                    rigidbody.AddForce(GetRandomDirectionVector() * _explodingForce);
                }
                else
                {
                    rigidbody.AddForce(Vector3.Cross(epicenter.transform.localPosition, scatteringObject.transform.localPosition).normalized * _explodingForce);
                }
            }
        }
    }

    private Vector3 GetRandomDirectionVector()
    {
        return new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)).normalized;
    }
}