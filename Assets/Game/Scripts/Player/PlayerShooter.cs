using UnityEngine;
public class PlayerShooter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject turret;

    [Header("RSO")]
    [SerializeField] private SSO_EntityData ssoPlayerData;

    public void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, spawnPoint.position, turret.transform.rotation);
        bullet.SetDamage(ssoPlayerData.damage);
    }
}