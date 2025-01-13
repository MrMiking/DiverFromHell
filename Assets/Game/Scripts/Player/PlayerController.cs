using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float currentHealth;

    [Header("References")]
    [SerializeField] PlayerMovement movement;
    [SerializeField] PlayerInput input;

    [Header("RSE")]
    [SerializeField] private RSE_OnGameStart rseOnGameStart;
    [SerializeField] private RSE_OnPlayerDeath rseOnPlayerDeath;
    [Space(10)]
    [SerializeField] private RSO_PlayerShooting rsoPlayerShooting;
    [SerializeField] private RSO_PlayerRotation rsoPlayerRotation;

    [Header("RSO")]
    [SerializeField] private RSO_PlayerTransform rsoPlayerTransform;

    public bool canMove = false;

    private float lastRotationAngle;

    private void OnEnable()
    {
        rseOnGameStart.action += OnGameStart;
        rseOnPlayerDeath.action -= OnDeath;
    }

    private void OnDisable()
    {
        rseOnGameStart.action -= OnGameStart;
        rseOnPlayerDeath.action -= OnDeath;
    }

    private void Awake()
    {
        rsoPlayerTransform.Value = transform;
    }

    private void Update()
    {
        if(canMove)
        {
            movement.MoveTurret();
            movement.Move(input.GetMovementInput());

            UpdateSpinData();
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

    public void TakeDamage(float ammount)
    {
        currentHealth -= ammount;

        if (currentHealth < 0)
        {
            rseOnPlayerDeath.Call();
        }
    }

    private void OnGameStart() => canMove = true;

    private void OnDeath() => canMove = false;
}