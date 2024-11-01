using UnityEngine;

[RequireComponent(typeof(CubeSpawner))]
public class CubeCatcher : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance;

    private CubeSpawner _cubeSpawner;
    private int _mouseButtonToCatch = 0;

    private void Awake()
    {
        _cubeSpawner = GetComponent<CubeSpawner>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonToCatch))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit _hit, _maxDistance))
                if (_hit.transform.TryGetComponent(out Cube cube))
                    _cubeSpawner.TryToSpawn(cube);
        }
    }
}