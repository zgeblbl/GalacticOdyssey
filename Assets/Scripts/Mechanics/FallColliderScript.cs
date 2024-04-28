using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallColliderScript : MonoBehaviour
{
    [SerializeField] float xCoor;
    [SerializeField] float yCoor;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(xCoor, yCoor, 0);
            StartCoroutine(collision.GetComponent<PlayerHealth>().TakeDamage(4));
        }
    }
}
