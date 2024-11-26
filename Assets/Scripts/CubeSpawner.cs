using System.Collections;
using UnityEngine;
using UnityEngine.Pool;


public class CubeSpawner : MonoBehaviour
{
    public float TimeBetweenSpawn = 1f;
    public Cube Prefab;
    private Bounds _bounds;

    private ObjectPool<Cube> _pool;
    private int _poolCapacity = 5;
    private int _poolMaxSize = 10;

    private float _releaseDelayMin = 2f;
    private float _releaseDelayMax = 5f;

    private Color _spawnedColor = Color.white;
    private Color _groundedColor = Color.cyan;

    private void Awake()
    {
        _bounds = GetComponent<Renderer>().bounds;

        _pool = new ObjectPool<Cube>(
            createFunc: () => ActionOnCreate(),
            actionOnGet: (pooledObject) => ActionOnGet(pooledObject),
            actionOnRelease: (pooledObject) => ActionOnRelease(pooledObject),
            actionOnDestroy: (pooledObject) => Destroy(pooledObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
            );
    }
    private void Start()
    {
        StartCoroutine(CubeSpawn());
    }

    private IEnumerator CubeSpawn()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(TimeBetweenSpawn);

        while (enabled)
        {
            Cube cube = _pool.Get();
            cube.TouchGround += ReleaseCube;
            ChangeColor(cube, _spawnedColor);
            yield return waitForSeconds;
        }
    }

    private Vector3 GetRandomPosition(Bounds bounds)
    {
        return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z));
    }

    private Cube ActionOnCreate()
    {
        Cube newObject = Instantiate(Prefab);
        return newObject;
    }

    private void ActionOnGet(Cube pooledObject)
    {
        pooledObject.transform.position = GetRandomPosition(_bounds);
        pooledObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        pooledObject.gameObject.SetActive(true);
    }

    private void ActionOnRelease(Cube pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        pooledObject.TouchGround -= ReleaseCube;
    }

    private void ReleaseCube(Cube cube)
    {
        ChangeColor(cube, _groundedColor);
        StartCoroutine(DelayToRelease(cube));
    }

    private IEnumerator DelayToRelease(Cube cube)
    {
        yield return new WaitForSeconds(Random.Range(_releaseDelayMin, _releaseDelayMax));
        _pool.Release(cube);
    }

    private void ChangeColor(Cube cube, Color color)
    {
        cube.GetComponent<Renderer>().material.color = color;
    }
}
