using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOnRain : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var parent = transform.parent;
            parent.GetComponentInChildren<ParticleSystem>().Play();
            parent.gameObject.GetComponentInChildren<Wind>().IsWindy = true;
        }
    }
}
