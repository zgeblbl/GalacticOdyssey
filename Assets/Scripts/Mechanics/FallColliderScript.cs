using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallColliderScript : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().health = 1;
            StartCoroutine(collision.GetComponent<PlayerHealth>().TakeDamage());
        }
    }
}
