using UnityEngine;
public class PlayerController : MonoBehaviour, IDamageable
{
    [Header("References")]
    [SerializeField] PlayerShooter shooter;
    [SerializeField] PlayerMovement movement;
    [SerializeField] PlayerInput input;

    [Header("RSE")]
    [SerializeField] private RSE_OnGameStart rseOnGameStart;
    [SerializeField] private RSE_OnPlayerDeath rseOnPlayerDeath;
    [Space(10)]
    [SerializeField] private RSO_PlayerShooting rsoPlayerShooting;
    [SerializeField] private RSO_PlayerRotation rsoPlayerRotation;

    [Header("RSO")]
    [SerializeField] private RSO_PlayerHealth rsoPlayerHealth;
    [SerializeField] private RSO_PlayerTransform rsoPlayerTransform;

    [Header("SSO")]
    [SerializeField] private SSO_EntityData ssoPlayerData;

    public bool canMove = false;
    public bool canShoot = false;

    private float lastRotationAngle;

    private void OnEnable()
    {
        rseOnGameStart.action += OnGameStart;
        rseOnPlayerDeath.action += OnDeath;
    }

    private void OnDisable()
    {
        rseOnGameStart.action -= OnGameStart;
        rseOnPlayerDeath.action -= OnDeath;
    }

    private void Start()
    {
        rsoPlayerTransform.Value = transform;
        rsoPlayerHealth.Value = ssoPlayerData.health;
    }

    private void Update()
    {
        if(canMove)
        {
            movement.MoveTurret();
            movement.Move(input.GetMovementInput());

            UpdateSpinData();
        }

        if (canShoot && input.GetShootInput)
        {
            shooter.Shoot();
        }
    }

    private void UpdateSpinData()
    {
        rsoPlayerShooting.Value = true;

        float currentRotationAngle = movement.Turret.transform.eulerAngles.y;
        bool isRotating = Mathf.Abs(currentRotationAngle - lastRotationAngle) > 0.1f;

        rsoPlayerRotation.Value.isRotating = isRotating;

        if (isRotating)
        {
            rsoPlayerRotation.Value.rotationDuration += Time.deltaTime;
        }
        else
        {
            rsoPlayerRotation.Value.rotationDuration = 0;
        }

        lastRotationAngle = currentRotationAngle;
    }

    public void TakeDamage(int ammount)
    {
        rsoPlayerHealth.Value -= ammount;

        if (rsoPlayerHealth.Value < 0)
        {
            rseOnPlayerDeath.Call();
        }
    }

    private void OnGameStart()
    {
        canMove = true;
        canShoot = true;
    }

    private void OnDeath()
    {
        canMove = false;
        canShoot = false;
    }
}