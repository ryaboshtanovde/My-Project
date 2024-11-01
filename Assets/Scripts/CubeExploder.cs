using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _baseExplodeForce = 1;
    [SerializeField] private float _baseExlodeRadius = 1;

    public void Explode(Cube epicenter)
    {
        float explodeModifier = epicenter.GetExplosionModifier();

        Collider[] overlappedColliders = Physics.OverlapSphere(epicenter.transform.position, _baseExlodeRadius * explodeModifier);

        foreach (Collider collider in overlappedColliders)
        {
            if (collider.TryGetComponent(out Cube cube))
            {
                if (cube != epicenter)
                {
                    Vector3 direction = Vector3.Cross(epicenter.transform.position, cube.transform.position).normalized;
                    float distance = Vector3.Distance(epicenter.transform.position, cube.transform.position);

                    cube.rigidBody.AddForce(direction * (1 / distance) * (_baseExplodeForce * explodeModifier));
                }
            }
        }

        Destroy(epicenter.gameObject);
    }
}