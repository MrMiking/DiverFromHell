using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float smoothSpeed = 5f;  // Smoothing speed for movement
    [SerializeField] private Vector3 posOffset;       // Fixed offset
    [SerializeField] private float mouseOffsetDistance = 3f; // Additional offset towards the mouse

    [Header("RSO")]
    [SerializeField] private RSO_PlayerTransform rsoPlayerTransform;

    private void LateUpdate()
    {
        if (rsoPlayerTransform == null || rsoPlayerTransform.Value == null) return;

        // Get the player's position
        Vector3 targetPosition = rsoPlayerTransform.Value.position;

        // Calculate fixed offset position
        Vector3 desiredPosition = targetPosition + posOffset;

        // Get the mouse position in world space
        Vector3 mousePosition = GetMouseWorldPosition(targetPosition.y);

        // Calculate direction from player to mouse and apply additional offset
        Vector3 directionToMouse = (mousePosition - targetPosition).normalized;
        Vector3 mouseOffset = directionToMouse * mouseOffsetDistance;

        // Add mouse-based offset to the desired position
        desiredPosition += mouseOffset;

        // Smoothly move the camera to the new desired position
        transform.position = math.lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Gets the mouse position in world space relative to the specified ground height.
    /// </summary>
    /// <param name="groundHeight">The height of the ground (e.g., player's Y position).</param>
    /// <returns>Mouse position in world coordinates.</returns>
    private Vector3 GetMouseWorldPosition(float groundHeight)
    {
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, groundHeight, 0)); // Ground plane at player's height
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance); // Mouse position on the ground plane
        }

        return Vector3.zero; // Fallback position
    }
}
