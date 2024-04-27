using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("hit");
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}
