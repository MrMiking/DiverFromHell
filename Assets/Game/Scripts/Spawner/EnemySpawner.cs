using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private EnemyController[] enemyPrefab;

    public void SpawnEnemy() => enemyPool.Get();

    private IObjectPool<EnemyController> enemyPool;

    private void Awake()
    {
        enemyPool = new ObjectPool<EnemyController>(CreateEnemy, OnGet, OnRelease);
    }

    private void OnGet(EnemyController enemy)
    {
        enemy.gameObject.SetActive(true);
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        enemy.transform.position = randomSpawnPoint.position;
    }

    private void OnRelease(EnemyController enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private EnemyController CreateEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefab.Length);
        EnemyController enemy = Instantiate(enemyPrefab[randomIndex]);
        enemy.SetPool(enemyPool);
        return enemy;
    }
}
