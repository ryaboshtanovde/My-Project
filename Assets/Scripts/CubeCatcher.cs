using UnityEngine;

public class CubeCatcher : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private float _maxDistance;
    [SerializeField] private GameObject _cubePrefab;

    private CubeSpawner _cubeSpawner = new CubeSpawner();
    private RaycastHit _hit;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, _maxDistance) && Input.GetMouseButtonDown(0) && _hit.collider.CompareTag("Cube"))
        {
            _cubeSpawner.TryToSpawn(_hit.transform.gameObject, _cubePrefab);
        }
    }
}
