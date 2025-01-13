using UnityEngine;
public class MeleeAttack : IAttack
{
    private readonly EntityAttackData attackData;

    public bool CanAttack() => true;

    public MeleeAttack(EntityAttackData attackData)
    {
        this.attackData = attackData;
    }

    public void ExecuteAttack(IDamageable target)
    {
        target.TakeDamage(attackData.damage);
    }
}