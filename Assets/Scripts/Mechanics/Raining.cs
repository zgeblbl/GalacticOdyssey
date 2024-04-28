using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        ps.Stop();
    }
    public void ChangeState(bool isFilling)
    {
        
        if (isFilling)
        {
            if (isRaining)
            {
                return;
            }
        
            ps.Play();
            isRaining = true;
        }
        else
        {
            if (!isRaining)
            {
                return;
            }
            
            ps.Stop();
            isRaining = false;
        }
    }

}
