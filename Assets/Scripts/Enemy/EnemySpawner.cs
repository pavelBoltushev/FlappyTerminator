using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy _template;
    [SerializeField] private float _spawnPeriodicity;

    private Enemy[] _spawnedReferencies;

    private void Start()
    {
        _spawnedReferencies = new Enemy[_spawnPoints.Length];
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_spawnPeriodicity);

        while (true)
        {
            yield return wait;

            int randomSpawnPointIndex = Random.Range(0, _spawnPoints.Length);

            if (_spawnedReferencies[randomSpawnPointIndex] == null)
            {
                Enemy spawned = Instantiate(_template, _spawnPoints[randomSpawnPointIndex].position, _template.transform.rotation);
                _spawnedReferencies[randomSpawnPointIndex] = spawned;
                spawned.SetSpawner(this);
            }
        }
    }

    public void RemoveSpawnedReference(Enemy spawnedToRemove)
    {
        for (int i = 0; i < _spawnedReferencies.Length; i++)
        {
            if (_spawnedReferencies[i] == spawnedToRemove)
                _spawnedReferencies[i] = null;
        }
    }

    public void DestroyAllSpawned()
    {
        for (int i = 0; i < _spawnedReferencies.Length; i++)
        {
            if(_spawnedReferencies[i] != null)
            {
                Destroy(_spawnedReferencies[i].gameObject);
                _spawnedReferencies[i] = null;
            }
        }
    }
}
