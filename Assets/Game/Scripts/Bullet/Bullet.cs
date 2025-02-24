using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifeTime;
    [SerializeField] private Explosion explosion;
    
    [HideInInspector] public int damage;

    private void Start() => Destroy(gameObject, lifeTime);

    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Untagged"))
        {
            Explosion tempExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
            tempExplosion.damage = damage;

            Destroy(gameObject);
        }
    }
}