using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float shootCooldown = 1f; // Time (in seconds) before the player can shoot again
    [SerializeField] private AudioClip shootSound;     // Sound effect played when shooting
    [SerializeField] private float shootSoundVolume = 1f; // Volume for the shoot sound (0.0 to 1.0)

    private float lastShootTime = 0f; // Tracks the last time the player fired


    public bool GetShootInput
    {
        get
        {
            if (Input.GetKey(KeyCode.Mouse0) && CanShoot())
            {
                HandleShoot();
                return true;
            }
            return false;
        }
    }

    public Vector3 GetMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        return new Vector3(horizontal, 0, vertical).normalized;
    }


    private bool CanShoot()
    {
        return Time.time >= lastShootTime + shootCooldown;
    }


    private void HandleShoot()
    {
        lastShootTime = Time.time;

        if (shootSound != null)
        {
            AudioSource.PlayClipAtPoint(shootSound, transform.position, shootSoundVolume);
        }
    }
}
