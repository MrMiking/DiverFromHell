using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private RSE_OnEnemyKilled rseOnEnemyKilled;
    [SerializeField] private RSO_PlayerPosition target;

    private IObjectPool<Enemy> enemyPool;

    public void SetPool(IObjectPool<Enemy> pool)
    {
        enemyPool = pool;
    }

    private void Update()
    {
        agent.SetDestination(target.Value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rseOnEnemyKilled.Call();
            enemyPool.Release(this);
        }
    }
}
