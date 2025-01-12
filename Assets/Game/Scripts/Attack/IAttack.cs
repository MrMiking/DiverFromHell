using UnityEngine;
public interface IAttack
{
    void ExecuteAttack(GameObject target);
    bool CanAttack();
}