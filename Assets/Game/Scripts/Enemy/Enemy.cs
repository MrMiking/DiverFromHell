using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Settings")]
    [SerializeField] private float currentHealth;

    [Header("References")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private SSO_EntityData entityData;
    [SerializeField] private RSE_OnEnemyKilled rseOnEnemyKilled;
    [SerializeField] private RSO_PlayerPosition target;

    private float lastAttackTime;

    public IAttack attack => AttackFactory.CreateAttack(entityData.attackData.attackType, entityData.attackData);

    private IObjectPool<Enemy> enemyPool;

    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        agent.updatePosition = false;
    }

    private void Start()
    {
        agent.speed = entityData.speed;

        currentHealth = entityData.health;
        lastAttackTime = -entityData.attackData.cooldown;
    }

    public void SetPool(IObjectPool<Enemy> pool)
    {
        enemyPool = pool;
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.Value);

        transform.position = Vector3.SmoothDamp(transform.position, agent.nextPosition, ref velocity, 0.1f);
    }

    public void TakeDamage(float ammount)
    {
        currentHealth -= ammount;

        if(currentHealth < 0)
        {
            rseOnEnemyKilled.Call();
            enemyPool.Release(this);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            agent.isStopped = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(Time.time - lastAttackTime >= entityData.attackData.cooldown)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                attack.ExecuteAttack(collision.gameObject);
                lastAttackTime = Time.time;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            agent.isStopped = false;
        }
    }
}