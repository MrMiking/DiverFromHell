using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Follow Settings")]
    public Transform target; // Reference to the tank's lower half
    public Vector3 offset = new Vector3(0, 10, -10); // Offset from the target
    public float smoothSpeed = 0.125f; // Smoothness factor

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: No target assigned!");
            return;
        }

        // Desired position with offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply position
        transform.position = smoothedPosition;

        // Lock rotation to keep Z-axis fixed
        transform.rotation = Quaternion.Euler(90f, 0f, 0f); // Top-down fixed rotation
    }
}
