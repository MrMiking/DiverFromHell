using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 posOffset;

    [Header("RSO")]
    [SerializeField] private RSO_PlayerTransform rsoPlayerTransform;

    private void LateUpdate()
    {
        Vector3 targetPosition = rsoPlayerTransform.Value.position;
        Vector3 desiredPosition = targetPosition + posOffset;

        transform.position = math.lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
