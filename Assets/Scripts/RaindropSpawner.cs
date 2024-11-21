using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent (typeof(Renderer))]
public class RaindropSpawner : MonoBehaviour
{
    public float TimeBetweenSpawn = 1f;
    public int SpawnCount = 1;
    public GameObject Prefab;
    private Bounds _bounds;
    private ObjectPool<GameObject> _pool;
    private int _poolCapacity = 5;
    private int _poolMaxSize = 10;

    private void Awake()
    {
        _bounds = GetComponent<Renderer>().bounds;

        _pool = new ObjectPool<GameObject>(
            createFunc: () => CreatePooledObject(),
            actionOnGet: (pooledObject) => ActionOnGet(pooledObject),
            actionOnRelease: (pooledObject) => pooledObject.SetActive(false),
            actionOnDestroy: (pooledObject) => Destroy(pooledObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
            );
    }
    private void Start()
    {
        StartCoroutine(RaindropSpawn());
    }

    private IEnumerator RaindropSpawn()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(TimeBetweenSpawn);

        while (enabled)
        {
            _pool.Get();
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

    private GameObject CreatePooledObject()
    {
        GameObject newObject = Instantiate(Prefab);
        newObject.AddComponent<Raindrop>();
        newObject.GetComponent<Raindrop>().Spawner = this;
        return newObject;
    }
    
    private void ActionOnGet(GameObject pooledObject)
    {
        pooledObject.transform.position = GetRandomPosition(_bounds);
        pooledObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        pooledObject.SetActive(true);
    }

    public void ReleaseOnPool(GameObject gameObject)
    {
        _pool.Release(gameObject);
    }
}

