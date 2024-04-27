using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }
}
