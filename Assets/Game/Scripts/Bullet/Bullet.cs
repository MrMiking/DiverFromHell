using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifeTime;
    
    private int damage;

    public void SetDamage(int damage)
    {
        this.damage = damage;   
    }

    private void Start()
    {
        Destroy(gameObject, 2);
    }

    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent(out IDamageable damageable) && !other.gameObject.CompareTag("Player"))
        {
            damageable.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}