using UnityEngine;

[RequireComponent(typeof(CubeSpawner))]

public class CubeCatcher : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance;

    private CubeSpawner _cubeSpawner;
    private RaycastHit _hit;
    private int _leftMouseButton = 0;

    private void Awake()
    {
        _cubeSpawner = GetComponent<CubeSpawner>();
    }

    private void Update()
    {
        Ray _ray;
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, _maxDistance) && 
            Input.GetMouseButtonDown(_leftMouseButton) && 
            _hit.transform.TryGetComponent(out Cube cube))
        {
            _cubeSpawner.TryToSpawn(_hit.transform.gameObject);
        }
    }
}
