using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float angleTolerance;

    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject turret;

    private Vector3 targetDirection;

    public Vector3 GetDirection => targetDirection;

    public void MoveTurret()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = Vector3.Distance(Camera.main.transform.position, transform.position);

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = new Vector3(worldMousePosition.x, transform.position.y, worldMousePosition.z);

        turret.transform.rotation = Quaternion.LookRotation(direction - transform.position);
    }

    public void Move(Vector3 direction)
    {
        if(direction == Vector3.zero) return;

        targetDirection = direction.normalized;

        float angle = Vector3.Angle(transform.forward, targetDirection);

        if (angle <= angleTolerance)
        {
            rb.velocity = transform.forward * moveSpeed;
        }

        RotateTowardsTarget();
    }

    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}