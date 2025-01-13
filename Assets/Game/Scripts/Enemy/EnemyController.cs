using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
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

    private void OnEnable()
    {
        currentHealth = entityData.health;
    }


    private void Awake()
    {
        movement.SetSpeed(entityData.speed);

        currentHealth = entityData.health;
        lastAttackTime = -entityData.cooldown;
    }

    private void Update()
    {
        movement.Move(rsoPlayerTransform.Value.transform.position);
    }

    public void SetPool(IObjectPool<EnemyController> pool)
    {
        enemyPool = pool;
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

    private void Attack()
    {
        Vector3 attackDirection = transform.forward;
        float attackAngle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;

        AttackAnimator attackTransform = GameObject.Instantiate(
        entityData.attackAnimation,
            attackSpawnPoint.position,
            transform.rotation);
        attackTransform.SetAttackData(entityData);
        attackTransform.onLoop = () => Object.Destroy(attackTransform.gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(Time.time - lastAttackTime >= entityData.cooldown)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Attack");
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }
}