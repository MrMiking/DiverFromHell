using UnityEngine;
public class FlickerFlash : MonoBehaviour
{
    [Header("RSE")]
    [SerializeField] private Animator animator; 
    [SerializeField] private RSE_PlayFlickerFlash playFlickerFlash;

    private void OnEnable()
    {
        playFlickerFlash.action += PlayFlickerFlash;
    }

    private void OnDisable()
    {
        playFlickerFlash.action -= PlayFlickerFlash;
    }

    private void PlayFlickerFlash()
    {
        animator.SetTrigger("PlayFlickerFlash");
    }
}