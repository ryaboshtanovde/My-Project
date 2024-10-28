using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private float _maxDistance;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private int _minCubesCount;
    [SerializeField] private int _maxCubesCount;    
    [SerializeField] private float _minChanceBoarder = 0f;
    [SerializeField] private float _maxChanceBoarder = 1f;

    private RaycastHit _hit;

    void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, _maxDistance) && Input.GetMouseButtonDown(0) && _hit.collider.CompareTag("Cube"))
        {
            float divisionChanche = _hit.transform.localScale.x / _cubePrefab.transform.localScale.x;

            if (Random.Range(_minChanceBoarder, _maxChanceBoarder) <= divisionChanche)
            {
                for (int i = 0; i < Random.Range(_minCubesCount, _maxCubesCount); i++)
                {
                    GameObject cube = Instantiate(_cubePrefab);

                    cube.transform.localScale = _hit.transform.localScale/2;
                    cube.transform.localPosition = _hit.transform.localPosition;
                }
            }

            Destroy(_hit.collider.gameObject);
        }
    }
}
