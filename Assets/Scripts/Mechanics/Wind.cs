using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wind : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsWindy { get; set; }
    [SerializeField]public float windPower;
    void Start()
    {
        GetComponentInChildren<ParticleSystem>().Stop();
        IsWindy = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (IsWindy) {
            var ss = FindObjectsOfType<MonoBehaviour>().OfType<IWindAffected>();
            foreach (IWindAffected s in ss)
            {
                s.ApplyWind(windPower);
            }
        }
        
        
    }
}
