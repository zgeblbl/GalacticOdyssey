using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource explosionEffect;
    public AudioSource soundtrack;
    void Start()
    {
        if (soundtrack != null && soundtrack.clip != null)
        {
            soundtrack.Play();
        }
    }

    
    public void ExplosionEffect()
    {
        if (explosionEffect != null && explosionEffect.clip != null)
        {
            explosionEffect.Play();
        }
    }
}
