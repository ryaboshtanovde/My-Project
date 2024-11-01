using UnityEngine;

[RequireComponent(typeof(CubeScatter))]
public class CubeSpawner : MonoBehaviour
{
    private int _minCubesCount = 2;
    private int _maxCubesCount = 6;
    private float _minChanceBoarder = 0f;
    private float _maxChanceBoarder = 1f;
    private float _divisionPower = 2;

    private CubeScatter _cubeScatter;

    private void Awake()
    {
        _cubeScatter = GetComponent<CubeScatter>();
    }

    public void TryToSpawn(Cube hittedObject)
    {
        float divisionChanche = hittedObject.GetComponent<Cube>().DivisionChanche;

        if (Random.Range(_minChanceBoarder, _maxChanceBoarder) <= divisionChanche)
        {
            int cubeCount = Random.Range(_minCubesCount, _maxCubesCount + 1);
            Cube[] cubes = new Cube[cubeCount];

            for (int i = 0; i < cubeCount; i++)
            {
                Cube cube = Instantiate(hittedObject);

                cube.ChangeScale(hittedObject.transform.localScale / _divisionPower);
                cube.SetDivisionChanche(divisionChanche / _divisionPower);

                cubes[i] = cube;
            }

            _cubeScatter.ScatterAround(cubes, hittedObject);
        }

        Destroy(hittedObject.gameObject);
    }
}