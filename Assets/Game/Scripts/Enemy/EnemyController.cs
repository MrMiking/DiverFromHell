using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class EnemyController : MonoBehaviour, IDamageable
{
    [Header("Settings")]
    [SerializeField] private float currentHealth;

    [Header("References")]
    [SerializeField] private EnemyMovement movement;

    [Header("SSO")]
    [SerializeField] private SSO_EntityData entityData;

    [Header("RSE")]
    [SerializeField] private RSE_OnEnemyKilled rseOnEnemyKilled;

    [Header("RSO")]
    [SerializeField] private RSO_PlayerTransform rsoPlayerTransform;

    private float lastAttackTime;

    public IAttack attack => AttackFactory.CreateAttack(entityData.attackData.attackType, entityData.attackData);

    private IObjectPool<EnemyController> enemyPool;


    private void Awake()
    {
        movement.SetSpeed(entityData.speed);

        currentHealth = entityData.health;
        lastAttackTime = -entityData.attackData.cooldown;
    }

    private void Update()
    {
        movement.Move(rsoPlayerTransform.Value.transform.position);
    }

    public void SetPool(IObjectPool<EnemyController> pool)
    {
        enemyPool = pool;
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

    private void OnCollisionStay(Collision collision)
    {
        if(Time.time - lastAttackTime >= entityData.attackData.cooldown)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable damageable) && collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Attackkkk");
                attack.ExecuteAttack(gameObject, damageable);
                lastAttackTime = Time.time;
            }
        }
    }
}