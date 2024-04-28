using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 5f;
    public GameObject explosionPrefab;
    public float explosionDuration = 0.5f;
    public int numPieces = 6;

    private Rigidbody2D rb;
    private PlayerHealth playerHealth;
    private AudioManager audioManager;

    int sceneCount;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
        audioManager = FindObjectOfType<AudioManager>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void InitializeAsteroid(int count)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), 0f);
        spawnPosition = Camera.main.ViewportToWorldPoint(spawnPosition);
        spawnPosition.z = 0f;
        spawnPosition.y = Random.Range(6,10);
        spawnPosition.x += 10;
        transform.position = spawnPosition;

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        sceneCount = count;
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3(1f, -5f, 0f).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);

        if (gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    bool IsInView()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 10 && screenPoint.y <= 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Asteroid"))
        {
            if (collision != null && collision.gameObject != null)
            {
                Explode();
                if (collision.gameObject.CompareTag("Player") && playerHealth != null)
                {
                    playerHealth.StartCoroutine(playerHealth.TakeDamage(sceneCount + 4));
                }
            }
        }
    }

    void Explode()
    {
        if (audioManager!=null)
        {
            audioManager.ExplosionEffect();
        }

        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Destroy the explosion particle system after its duration
        Destroy(explosion, explosionDuration);

        // Destroy the asteroid object
        Destroy(gameObject);
    }
}
