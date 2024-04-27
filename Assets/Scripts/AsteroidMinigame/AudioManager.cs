using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource explosionEffect;
    void Start()
    {
        
    }

    
    public void ExplosionEffect()
    {
        if (explosionEffect != null && explosionEffect.clip != null)
        {
            explosionEffect.Play();
        }
    }
}
