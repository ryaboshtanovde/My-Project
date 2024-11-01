using UnityEngine;

[RequireComponent(typeof(CubeExploder))]
public class CubeSpawner : MonoBehaviour
{
    private int _minCubesCount = 2;
    private int _maxCubesCount = 6;
    private float _minChanceBoarder = 0f;
    private float _maxChanceBoarder = 1f;
    private float _minPositionShift = 0.01f;
    private float _maxPositionShift = 0.5f;
    private float _divisionPower = 2;

    private CubeExploder _cubeExploder;

    private void Awake()
    {
        _cubeExploder = GetComponent<CubeExploder>();
    }

    public void TryToSpawn(Cube hittedObject)
    {
        float divisionChanche = hittedObject.GetComponent<Cube>().divisionChanche;

        if (Random.Range(_minChanceBoarder, _maxChanceBoarder) <= divisionChanche)
        {
            int cubeCount = Random.Range(_minCubesCount, _maxCubesCount + 1);

            for (int i = 0; i < cubeCount; i++)
            {
                Cube cube = Instantiate(hittedObject);

                cube.ChangeScale(hittedObject.transform.localScale / _divisionPower);
                cube.SetDivisionChanche(divisionChanche / _divisionPower);
                AddRandomPositionShift(cube.transform);
            }
        }
        _cubeExploder.Explode(hittedObject);
    }

    private void AddRandomPositionShift(Transform transform)
    {
        Vector3 newPosition = transform.position + new Vector3(Random.Range(_minPositionShift, _maxPositionShift), 0, Random.Range(_minPositionShift, _maxPositionShift));

        transform.position = newPosition;
    }
}