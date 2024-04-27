using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wind : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(-1, 1f)]
    public float windPower;
    void Start()
    {
        windPower = 0.05f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var ss = FindObjectsOfType<MonoBehaviour>().OfType<IWindAffected>();
        foreach (IWindAffected s in ss)
        {
            s.ApplyWind(windPower);
        }
        
    }
}
