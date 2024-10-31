using UnityEngine;

public class Exploding : MonoBehaviour
{
    [SerializeField] private float explodingForce = 10;

    public void ScatterAround(GameObject[] objects, GameObject epicenter)
    {
        foreach (GameObject scatteringObject in objects)
        {
            if (scatteringObject.transform.localPosition == epicenter.transform.localPosition)
            {
                scatteringObject.GetComponent<Rigidbody>().AddForce(GetRandomDirectionVector() * explodingForce);
            }
            else
            {
                scatteringObject.GetComponent<Rigidbody>().AddForce(Vector3.Cross(epicenter.transform.localPosition, scatteringObject.transform.localPosition).normalized * explodingForce);
            }
        }
    }

    private Vector3 GetRandomDirectionVector()
    {
        return new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)).normalized;
    }
}