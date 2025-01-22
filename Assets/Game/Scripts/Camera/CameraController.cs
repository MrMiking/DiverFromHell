using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Reference")]
    public Camera mainCamera;

    [Header("Settings")]
    [SerializeField] private float smoothSpeed = 5.0f;
    [SerializeField] private float distance = 10.0f;

    [Header("FOV Settings")]
    [SerializeField] private float maxFOV;
    [SerializeField] private float minFOV;
    [SerializeField] private float dezoomFOV;
    [SerializeField] private float zoomSpeed;

    [Header("RSO")]
    [SerializeField] private RSO_InputShoot inputShoot;
    [SerializeField] private RSO_PlayerTransform rsoPlayerTransform;
    [SerializeField] private RSE_PlayShake playShake;

    private void OnEnable()
    {
        playShake.action += PlayCameraShake;
    }

    private void OnDisable()
    {
        playShake.action -= PlayCameraShake;
    }

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = rsoPlayerTransform.Value.position + new Vector3(0, distance, 0);

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);

        Dezoom();
        ReZoom();
    }

    private void PlayCameraShake(float duration, float magnitude)
    {
        StopAllCoroutines();
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    private void ReZoom()
    {
        if (mainCamera.fieldOfView <= minFOV) 
        { 
            mainCamera.fieldOfView = minFOV;
        }else
        {
            mainCamera.fieldOfView -= Time.deltaTime * zoomSpeed;
        }
    }

    private void Dezoom()
    {
        bool canDezoom = true;

        if (inputShoot.Value && canDezoom) 
        {

            Debug.Log("Has shoot");

            mainCamera.fieldOfView += dezoomFOV;

            if(mainCamera.fieldOfView >= maxFOV) mainCamera.fieldOfView = maxFOV;

            canDezoom = false;
        }
        else canDezoom = true;
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