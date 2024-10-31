using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private int _minCubesCount = 2;
    private int _maxCubesCount = 6;
    private float _minChanceBoarder = 0f;
    private float _maxChanceBoarder = 1f;
    private Exploding _exploding = new Exploding();

    public void TryToSpawn(GameObject hittedObject, GameObject prefab)
    {
        float divisionChanche = hittedObject.GetComponent<Cube>().DivisionChanche;

        if (Random.Range(_minChanceBoarder, _maxChanceBoarder) <= divisionChanche)
        {
            int cubeCount = Random.Range(_minCubesCount, _maxCubesCount + 1);
            GameObject[] cubes = new GameObject[cubeCount];

            for (int i = 0; i < cubeCount; i++)
            {
                GameObject cube = Instantiate(prefab);

                cube.transform.localScale = hittedObject.transform.localScale / 2;
                cube.transform.localPosition = hittedObject.transform.localPosition;
                cube.GetComponent<Cube>().SetDivisionChanche(divisionChanche / 2);

                cubes[i] = cube;
            }
            _exploding.ScatterAround(cubes, hittedObject);
        }
        Destroy(hittedObject);
    }
}
