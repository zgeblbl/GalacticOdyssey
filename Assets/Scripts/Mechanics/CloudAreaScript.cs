using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAreaScript : MonoBehaviour
{
    bool underCloud = false; 
    private float timeToDie = 2f; // Time before the character dies if not under clouds

    private float timer; // Timer to track time not under clouds

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SafeArea"))
        {
            timer = 0f;
            Debug.Log("Under cloud!");
            underCloud = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SafeArea"))
        {
            timer = 0f;
            underCloud = false;
        }
    }

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;
        Debug.Log(timer);
        // Check if the character should die
        if (timer >= timeToDie && !underCloud)
        {
            // Call a method to handle the character's death (e.g., respawn, game over, etc.)
            StartCoroutine(gameObject.GetComponent<PlayerHealth>().TakeDamage(9));
        }
    }
}
