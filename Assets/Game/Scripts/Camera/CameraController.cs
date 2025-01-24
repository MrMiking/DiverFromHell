using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Camera mainCamera;

    [Header("Settings")]
    [SerializeField] private float smoothSpeed = 5.0f;
    [SerializeField] private float distance = 10.0f;
    [Space(10)]
    [SerializeField] private float maxFOV;
    [SerializeField] private float minFOV;
    [SerializeField] private float dezoomFOV;
    [SerializeField] private float zoomSpeed;
    
    [Header("SakeCamera")]
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeMagnitude;

    [Header("RSO")]
    [SerializeField] private RSO_InputShoot inputShoot;
    [SerializeField] private RSO_PlayerTransform rsoPlayerTransform;

    [Header("RSE")]
    [SerializeField] private RSE_OnPlayerShoot onPlayerShoot;
    [SerializeField] private RSE_PlayShake playShake;

    private Vector3 velocity = Vector3.zero;

    private void OnEnable()
    {
        onPlayerShoot.action += Dezoom;
        playShake.action += PlayCameraShake;
    }

    private void OnDisable()
    {
        onPlayerShoot.action -= Dezoom;
        playShake.action -= PlayCameraShake;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = rsoPlayerTransform.Value.position + new Vector3(0, distance, 0);

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);

        if (mainCamera.fieldOfView > minFOV) mainCamera.fieldOfView -= Time.deltaTime * zoomSpeed;
    }

    private void PlayCameraShake(float duration, float magnitude)
    {
        StopAllCoroutines();
        StartCoroutine(ShakeCoroutine(shakeDuration, shakeMagnitude));
    }

    private void Dezoom()
    {
        if (mainCamera.fieldOfView < maxFOV) mainCamera.fieldOfView += dezoomFOV;
    }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float z = Random.Range(-1f, 1f) * magnitude;

            transform.position += new Vector3(x, 0, z);

            elapsed += Time.deltaTime;

            yield return null;
        }
    }
}