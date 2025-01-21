using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifeTime;
    [SerializeField] private LayerMask layerMask;
    
    [HideInInspector] public int damage;

    private void Start() => Destroy(gameObject, 2);

    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Untagged") || other.gameObject.CompareTag("Enemy"))
        {
            if(other.gameObject.TryGetComponent(out IDamageable damageable)) damageable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}