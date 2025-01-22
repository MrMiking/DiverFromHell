using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float smoothSpeed = 5.0f;
    [SerializeField] private float distance = 10.0f;

    [Header("RSO")]
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
    }

    private void PlayCameraShake(float duration, float magnitude)
    {
        StopAllCoroutines();
        StartCoroutine(ShakeCoroutine(duration, magnitude));
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