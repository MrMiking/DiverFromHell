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

    private void Awake()
    {
        playerHealth.Value = playerData.health;
        playerTransform.Value = transform;
    }

    private void Update()
    {
        movement.MoveTurret();
        movement.Move(input.GetMovementInput());

        if(input.GetShootInput) shooter.Shoot();
    }

    public void TakeDamage(int ammount)
    {
        playerHealth.Value -= ammount;

        if (playerHealth.Value <= 0)
        {
            Debug.Log("Skill Issue");
        }
    }
}