using UnityEngine;
public interface IAttack
{
    void ExecuteAttack(GameObject attacker, IDamageable target);
}