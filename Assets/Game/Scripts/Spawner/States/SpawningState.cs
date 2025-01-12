using System.Collections;
using UnityEngine;
public class SpawningState : ISpawnerState
{
    private WaveSpawner spawner;

    public SpawningState(WaveSpawner spawner)
    {
        this.spawner = spawner;
    }

    public void Enter()
    {
        spawner.StartCoroutine(SpawnEnemies());
    }

    public void Update() { }

    public void Exit() { }

    private IEnumerator SpawnEnemies()
    {
        for(int i = 0;  i < spawner.currentWaveConfig.totalEnemies; i++)
        {
            spawner.enemySpawner.SpawnEnemy();
            yield return new WaitForSeconds(spawner.currentWaveConfig.spawnInterval);
        }
    }
}