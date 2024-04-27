using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raining : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isRaining;
    private ParticleSystem ps;
    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        isRaining = false;
    }
    

}
