using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector3 posOffset;
    [SerializeField] private float mouseOffsetDistance = 3f;
    [SerializeField] private float defaultShakeMagnitude = 0.5f;
    [SerializeField] private float defaultShakeDuration = 0.5f;

    [SerializeField] private RSO_PlayerTransform rsoPlayerTransform;

    public float cameraZoom;
    public float cameraDeZoom;
    public float cameraMaxZoom;
    public float cameraMinZoom;

    private Vector3 shakeOffset;
    private float shakeDuration;
    private float shakeMagnitude;
    public Camera cameraComponent;

    private void LateUpdate()
    {
        if (rsoPlayerTransform == null || rsoPlayerTransform.Value == null) return;

        Vector3 targetPosition = rsoPlayerTransform.Value.position;
        Vector3 desiredPosition = targetPosition + posOffset;
        Vector3 mousePosition = GetMouseWorldPosition(targetPosition.y);
        Vector3 directionToMouse = (mousePosition - targetPosition).normalized;
        Vector3 mouseOffset = directionToMouse * mouseOffsetDistance;
        desiredPosition += mouseOffset;

        if (shakeDuration > 0f)
        {
            shakeOffset = new Vector3(
                UnityEngine.Random.Range(-shakeMagnitude, shakeMagnitude),
                UnityEngine.Random.Range(-shakeMagnitude, shakeMagnitude),
                0);
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeOffset = Vector3.zero;
        }

        desiredPosition += shakeOffset;
        transform.position = math.lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        cameraComponent.fieldOfView -= cameraDeZoom * Time.deltaTime;

        if(cameraComponent.fieldOfView <= cameraMinZoom)
        {
            cameraComponent.fieldOfView = cameraMinZoom;

        }

    }

    private Vector3 GetMouseWorldPosition(float groundHeight)
    {
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, groundHeight, 0));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }

        return Vector3.zero;
    }

    public void StartShake()
    {
        shakeDuration = defaultShakeDuration;
        shakeMagnitude = defaultShakeMagnitude;
        ZoomOut();
    }

    public void ZoomOut()
    {
        cameraComponent.fieldOfView += cameraZoom;
        if (cameraComponent.fieldOfView >= cameraMaxZoom) 
        {
            cameraComponent.fieldOfView = cameraMaxZoom;
        }
    }

}



