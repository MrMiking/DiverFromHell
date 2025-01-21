using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float smoothSpeed = 5.0f;
    [SerializeField] private float distance = 10.0f;

    [Header("RSO")]
    [SerializeField] private RSO_PlayerTransform rsoPlayerTransform;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 desiredPosition = rsoPlayerTransform.Value.position + new Vector3(0, distance, 0);

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);
    }
}