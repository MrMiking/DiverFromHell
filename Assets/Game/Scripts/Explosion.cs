using System.Collections;
using UnityEngine;
public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;

    [HideInInspector] public int damage;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("dqfubiqdsghf");
        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
        }
    }
}