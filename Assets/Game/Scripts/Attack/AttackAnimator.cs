using UnityEngine;
public class AttackAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public delegate void OnLoopDel();
    public OnLoopDel onLoop;

    SSO_EntityData attackData;

    public void SetAttackData(SSO_EntityData attackData)
    {
        this.attackData = attackData;
    }

    public void AttackCompleted()
    {
        Debug.Log("Finished");
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(attackData.damage);
        }
    }
}