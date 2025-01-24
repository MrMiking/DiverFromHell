using System.Collections;
using UnityEngine;
public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject explosionParticle;

    [HideInInspector] public int damage;

    public AudioClip explosioneffect;
    public AudioSource audioSource;

    private void Awake()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
    }

    public void Destroy()
    {
        audioSource.PlayOneShot(explosioneffect);
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