using UnityEngine;

public class TankMovementController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float rotationSpeed = 5f;
    public float movementSpeed = 10f;
    public float angleTolerance = 45f;

    private Vector3 targetDirection;

    private void Update()
    {
        HandleTankMovement();
    }

    public void UpdateDirection(Vector3 direction)
    {
        targetDirection = direction;
    }

    private void HandleTankMovement()
    {
        if (targetDirection == Vector3.zero) return;

        float angle = Vector3.Angle(transform.forward, targetDirection);

        if (angle <= angleTolerance)
        {
            MoveAndRotateTank();
        }
        else
        {
            RotateTowardsTarget();
        }
    }

    private void MoveAndRotateTank()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
