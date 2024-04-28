using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource explosionEffect;
    public AudioSource coinEffect;
    public AudioSource soundtrack;
    public float musicVolume = 1.0f;
    void Start()
    {
        if (soundtrack != null && soundtrack.clip != null)
        {
            soundtrack.Play();
            musicVolume = PlayerPrefs.GetFloat("volume");
        }
    }

    private void Update()
    {
        soundtrack.volume = musicVolume;
        explosionEffect.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }


    public void ExplosionEffect()
    {
        if (explosionEffect != null && explosionEffect.clip != null)
        {
            explosionEffect.Play();
        }
    }public void CoinEffect()
    {
        if (coinEffect != null && coinEffect.clip != null)
        {
            coinEffect.Play();
        }
    }

    public void VolumeUpdater(float volume)
    {
        musicVolume = volume;
    }
}
