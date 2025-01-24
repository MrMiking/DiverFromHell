using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    [Header("Pitch Settings")]
    [SerializeField] private float maxVolume;
    [SerializeField] private float minVolume;
    [SerializeField] private float increaseScaleVolume;
    [SerializeField] private float soundSpeed;

    [SerializeField] RSE_OnPlayerShoot onPlayerShoot;

    private void Update()
    {
        musicSource.volume -= soundSpeed * Time.deltaTime;
        if(musicSource.volume <= minVolume) musicSource.volume = minVolume;       
        
    }

    private void OnEnable()
    {
        onPlayerShoot.action += SoundVolume;
    }

    private void OnDisable()
    {
        onPlayerShoot.action -= SoundVolume;
    }

    public void SoundVolume()
    {
        musicSource.volume += increaseScaleVolume;
        if (musicSource.volume >= maxVolume) musicSource.volume = maxVolume;

    }
}
