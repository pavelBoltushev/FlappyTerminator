using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class Enemy : MonoBehaviour
{
    [SerializeField] float _shootingPeridocity;

    private EnemySpawner _spawner;
    private Shooter _shooter;

    private void Start()
    {
        _shooter = GetComponent<Shooter>();
        StartCoroutine(Shoot());
    }

    private void OnDestroy()
    {
        _spawner.RemoveSpawnedReference(this);
    }

    public void SetSpawner(EnemySpawner spawner)
    {
        _spawner = spawner;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_shootingPeridocity);

        while (true)
        {
            yield return wait;

            _shooter.Shoot();
        }
    }
}
