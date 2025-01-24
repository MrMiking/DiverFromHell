
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public RSE_OnPlayerShoot onPlayerShoot;
    public RSE_OnEnemyKilled onEnemyKilled;

    public AudioClip firingSound;
    public AudioClip explosionSound;
    public AudioSource AudioSource;

    private void OnEnable()
    {
        onPlayerShoot.action += PlayShootSound;
        onEnemyKilled.action += PlayExplosionSound;
    }

    private void OnDisable()
    {
        onPlayerShoot.action -= PlayShootSound;
        onEnemyKilled.action -= PlayExplosionSound;
    }

    public void PlayShootSound()
    {
        AudioSource.PlayOneShot(firingSound);
    }

    public void PlayExplosionSound()
    {
        AudioSource.PlayOneShot(explosionSound);
    }

}
