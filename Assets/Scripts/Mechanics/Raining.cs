using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raining : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;

        settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0,210,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
