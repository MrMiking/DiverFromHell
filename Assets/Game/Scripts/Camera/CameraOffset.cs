using Unity.Mathematics;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float smoothSpeed = 5f;  // Speed of smoothing the camera movement
    [SerializeField] private Vector3 posOffset;       // Fixed offset from the current position
    [SerializeField] private float mouseOffsetDistance = 3f; // Distance to offset in the direction of the mouse

    private void LateUpdate()
    {
        // Start with the camera's current position
        Vector3 desiredPosition = transform.position + posOffset;

        // Calculate the mouse offset
        Vector3 mousePosition = GetMouseWorldPosition(transform.position.y);
        Vector3 directionToMouse = (mousePosition - transform.position).normalized;
        Vector3 mouseOffset = directionToMouse * mouseOffsetDistance;

        // Add the mouse-based offset
        desiredPosition += mouseOffset;

        // Smoothly move the camera to the desired position
        transform.position = math.lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }

    private Vector3 GetMouseWorldPosition(float groundHeight)
    {
        // Define a plane at the camera's ground height
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, groundHeight, 0));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance); // Get the mouse position on the plane
        }

        return Vector3.zero; // Fallback position
    }
}
