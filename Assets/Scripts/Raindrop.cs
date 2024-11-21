using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(Renderer))]
public class Raindrop : MonoBehaviour
{
    public RaindropSpawner _spawner;
    private Renderer _renderer;
    private float _disableDelayMin = 2f;
    private float _disableDelayMax = 5f;
    private float _disableDelay;
    private float _baseSize = 0.5f;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        transform.localScale = Vector3.one * _baseSize;
    }

    private void OnEnable()
    {
        _renderer.material.color = Color.white;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _renderer.material.color = Color.cyan;
        _disableDelay = Random.Range(_disableDelayMin, _disableDelayMax);
        StartCoroutine(DestroyWithDelay(_disableDelay));
    }

    private IEnumerator DestroyWithDelay(float disableDelay)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(disableDelay);

        yield return waitForSeconds;
        _spawner.ReleaseOnPool(gameObject);
    }
}
