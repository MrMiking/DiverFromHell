using UnityEngine;
public class PlayerShooter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject turret;

    [SerializeField] private float duration = 1.0f;
    [SerializeField] private float magnitude = 10.0f;

    [Header("RSO")]
    [SerializeField] private SSO_EntityData ssoPlayerData;

    [Header("RSE")]
    [SerializeField] private RSE_PlayShake playShake;
    [SerializeField] private RSE_PlayFlickerFlash playFlickerFlash;

    public void Shoot()
    {
        playShake.Call(duration, magnitude);
        playFlickerFlash.Call();
        Bullet bullet = Instantiate(bulletPrefab, spawnPoint.position, turret.transform.rotation);
        bullet.damage = ssoPlayerData.damage;
    }
}