using System.Collections;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour, IDamageable
{
    [Header("References")]
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerShooter shooter;
    [SerializeField] private PlayerInput input;

    [Header("RSO")]
    [SerializeField] private RSO_PlayerHealth playerHealth;
    [SerializeField] private RSO_PlayerTransform playerTransform;

    [Header("SSO")]
    [SerializeField] private SSO_EntityData playerData;

    private bool canShoot = true;

    private void Awake()
    {
        playerHealth.Value = playerData.health;
        playerTransform.Value = transform;
    }

    private void FixedUpdate()
    {
        movement.MoveTurret();
        movement.Move(input.GetMovementInput());
    }

    private void Update()
    {
        

        if (canShoot && input.GetShootInput)
        {
            StartCoroutine(ShootCooldwon());
            shooter.Shoot();
        }
    }

    public void TakeDamage(int ammount)
    {
        playerHealth.Value -= ammount;

        if (playerHealth.Value <= 0)
        {
            Debug.Log("Skill Issue");
        }
    }

    IEnumerator ShootCooldwon()
    {
        canShoot = false;
        yield return new WaitForSeconds(playerData.cooldown);
        canShoot = true;
    }
}