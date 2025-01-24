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

    [Header("Pitch Settings")]
    [SerializeField] private float maxPitch;
    [SerializeField] private float minPitch;
    [SerializeField] private float increasePitchVolume;
    [SerializeField] private float pitchSpeed;

    [SerializeField] RSE_OnPlayerShoot onPlayerShoot;

    private void Update()
    {
        musicSource.volume -= soundSpeed * Time.deltaTime;
        if(musicSource.volume <= minVolume) musicSource.volume = minVolume;       
        
        musicSource.pitch -= pitchSpeed * Time.deltaTime;
        if(musicSource.pitch <= minPitch) musicSource.pitch = minPitch;
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
        musicSource.pitch += increasePitchVolume;
        if (musicSource.volume >= maxVolume) musicSource.volume = maxVolume;
        if (musicSource.pitch >= maxPitch) musicSource.pitch = maxPitch;

    }
}
