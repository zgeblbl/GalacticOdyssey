using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("hit");
        // Check if the projectile collides with an object tagged as "Asteroid"
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}
