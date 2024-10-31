using UnityEngine;

public class CubeScatter: MonoBehaviour
{
    [SerializeField] private float _explodingForce = 10;

    public void ScatterAround(GameObject[] objects, GameObject epicenter)
    {
        foreach (GameObject scatteringObject in objects)
        {
            if (scatteringObject.transform.localPosition == epicenter.transform.localPosition)
            {
                scatteringObject.GetComponent<Rigidbody>().AddForce(GetRandomDirectionVector() * _explodingForce);
            }
            else
            {
                scatteringObject.GetComponent<Rigidbody>().AddForce(Vector3.Cross(epicenter.transform.localPosition, scatteringObject.transform.localPosition).normalized * _explodingForce);
            }
        }
    }

    private Vector3 GetRandomDirectionVector()
    {
        return new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)).normalized;
    }
}