using UnityEngine;
public class MeleeAttack : Attack, IAttack
{
    private IMove attackerMove;
    private AttackState attackState;

    private readonly EntityAttackData attackData;

    public MeleeAttack(EntityAttackData attackData)
    {
        this.attackData = attackData;
    }

    public void ExecuteAttack(GameObject attacker, IDamageable target)
    {
        SetStateAttacking();

        Vector3 attackDirection = attacker.transform.forward;
        Debug.Log(attackDirection);
        float attackAngle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;

        AttackAnimator attackTransform = GameObject.Instantiate(
            attackData.attackPrefab, 
            attacker.transform.position + attackData.attackSpawnPosition + attackDirection, 
            Quaternion.identity);
        attackTransform.SetAttackData(attackData);
        attackTransform.onLoop = () => Object.Destroy(attackTransform.gameObject);

        target.TakeDamage(attackData.damage);
    }

    private void SetStateAttacking()
    {
        attackState = AttackState.Attacking;
        if (attackerMove != null) attackerMove.Disable();
    }
}