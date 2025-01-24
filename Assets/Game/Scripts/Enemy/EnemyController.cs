using UnityEngine;
using UnityEngine.Pool;

public class EnemyController : MonoBehaviour, IDamageable
{
    [Header("Settings")]
    [SerializeField] private float currentHealth;

    [Header("References")]
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private Transform attackSpawnPoint;

    [Header("SSO")]
    [SerializeField] private SSO_EntityData entityData;

    [Header("RSE")]
    [SerializeField] private RSE_OnEnemyKilled rseOnEnemyKilled;

    [Header("RSO")]
    [SerializeField] private RSO_PlayerTransform rsoPlayerTransform;

    private float lastAttackTime;

    private IObjectPool<EnemyController> enemyPool;

    public void SetPool(IObjectPool<EnemyController> pool) => enemyPool = pool;

    private void OnEnable()
    {
        movement.SetSpeed(entityData.speed);

        currentHealth = entityData.health;
        lastAttackTime = -entityData.cooldown;
    }

    private void Update()
    {
        movement.Move(rsoPlayerTransform.Value.transform.position);
    }

    public void TakeDamage(int ammount)
    {
        currentHealth -= ammount;

        if(currentHealth < 0)
        {
            rseOnEnemyKilled.Call();
            enemyPool.Release(this);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(Time.time - lastAttackTime >= entityData.cooldown)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if(collision.gameObject.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(entityData.damage);
                }
                lastAttackTime = Time.time;
            }
        }
    }
}