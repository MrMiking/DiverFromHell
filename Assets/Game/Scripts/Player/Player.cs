using UnityEngine;
public class Player : MonoBehaviour, IDamageable
{
    [Header("Settings")]
    public float currentHealth;
    public float health;
    [Header("References")]

    [SerializeField] private SSO_EntityData playerData;
    [Space(10)]
    [SerializeField] private RSO_PlayerPosition rsoPlayerPosition;
    [SerializeField] private RSO_PlayerRotation rsoPlayerRotation;
    [SerializeField] private RSO_PlayerShooting rsoPlayerShooting;
    [Space(10)]
    [SerializeField] private RSE_OnPlayerKilled rseOnPlayerKilled;
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]

    private float lastRotationAngle;

    private void Update()
    {
        rsoPlayerShooting.Value.isShooting = true;
        rsoPlayerPosition.Value = transform.position;

        float currentRotationAngle = transform.eulerAngles.y;
        bool isRotating = Mathf.Abs(currentRotationAngle - lastRotationAngle) > 0.1f;

        rsoPlayerRotation.Value.isRotating = isRotating;

        if(isRotating )
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
            rseOnPlayerKilled.Call();
        }
    }
}