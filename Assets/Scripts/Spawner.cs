using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Spawnpoint> _spawnpoints;
    [SerializeField] private Enemy _enemyPrefab;

    private float _spawnTimer = 2f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies() 
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnTimer);

        while (enabled)
        {
            Instantiate(_enemyPrefab, GetRandomSpawnpoint()).SetDirection(GetRandomDitection());

            yield return waitForSeconds; 
        }
    }

    private Vector3 GetRandomDitection()
    {
        return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    private Transform GetRandomSpawnpoint()
    {
        return _spawnpoints[Random.Range(0, _spawnpoints.Count)].transform;
    }
}
