using UnityEngine;
public class MeleeAttack : IAttack
{
    private readonly EntityAttackData attackData;
    private float lastAttackTime;

    public bool CanAttack() => true;

    public MeleeAttack(EntityAttackData attackData)
    {
        this.attackData = attackData;
        lastAttackTime = -this.attackData.cooldown;
    }

    public void ExecuteAttack(GameObject target)
    {
        if (target.TryGetComponent(out IDamageable damageable))
        {
            Debug.Log("Attack");
            damageable.TakeDamage(attackData.damage);
        }
    }
}