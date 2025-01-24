using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public RSE_OnPlayerShoot onPlayerShoot;

    public AudioClip firingSound;
    public AudioSource AudioSource;

    private void OnEnable()
    {
        onPlayerShoot.action += PlayShootSound;
    }

    private void OnDisable()
    {
        onPlayerShoot.action -= PlayShootSound;
    }

    public void PlayShootSound()
    {
        AudioSource.PlayOneShot(firingSound);
    }

}
