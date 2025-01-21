using System.Collections;
using UnityEngine;
public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;

    [HideInInspector] public int damage;

    private void Awake()
    {
        StartCoroutine("ExplosionDelay");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(damage);
        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
        }
    }

    IEnumerator ExplosionDelay()
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }
}