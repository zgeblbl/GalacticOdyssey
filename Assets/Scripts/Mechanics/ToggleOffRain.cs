using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOffRain : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var parent = transform.parent;
            parent.GetComponentInChildren<ParticleSystem>().Stop();
            parent.gameObject.GetComponentInChildren<Wind>().IsWindy = false;
        }
    }
}
