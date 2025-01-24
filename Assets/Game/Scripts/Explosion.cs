using UnityEngine;
public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject explosionParticle;

    [HideInInspector] public int damage;

    private void Awake()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
        }
    }
}