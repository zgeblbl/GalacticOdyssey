using UnityEngine;

public class SpaceshipShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public AudioSource shootingAudio;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 spawnPosition = transform.position + transform.up;

        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * projectileSpeed;
        if (shootingAudio != null && shootingAudio.clip != null)
        {
            shootingAudio.Play();
        }
    }

}
