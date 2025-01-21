using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private AudioClip[] soundEffects; // List of sound effects to choose from
    [SerializeField] private float volume = 1f;       // Volume for the sound (0.0 to 1.0)

    [SerializeField] private RSE_OnEnemyKilled rseOnEnemyKilled;
    public float soundVolume;

    private void OnEnable()
    {
        rseOnEnemyKilled.action += PlayRandomSound;
    }

    private void OnDisable()
    {
        rseOnEnemyKilled.action -= PlayRandomSound;
    }


    public void PlayRandomSound()
    {
        if (soundEffects == null || soundEffects.Length == 0)
        {
            Debug.LogWarning("No sound effects assigned to RandomSoundPlayer.");
            return;
        }

        // Pick a random sound effect from the list
        AudioClip randomSound = soundEffects[Random.Range(0, soundEffects.Length)];

        // Play the sound at the object's position with the specified volume
        if (randomSound != null)
        {
            AudioSource.PlayClipAtPoint(randomSound, transform.position, volume = soundVolume);
        }
    }
}
