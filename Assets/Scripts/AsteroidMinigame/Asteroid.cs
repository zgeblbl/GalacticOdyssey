using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 5f;
    public GameObject asteroidPiecePrefab;
    public int numPieces = 6;

    private Rigidbody2D rb;
    private PlayerHealth playerHealth;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    public void InitializeAsteroid()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), 0f);
        spawnPosition = Camera.main.ViewportToWorldPoint(spawnPosition);
        spawnPosition.z = 0f;
        transform.position = spawnPosition;

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (!IsInView())
        {
            Destroy(gameObject);
        }
    }

    bool IsInView()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
        playerHealth.StartCoroutine(playerHealth.TakeDamage());
        print("damage");

    }

    void Explode()
    {
        for (int i = 0; i < numPieces; i++)
        {
            GameObject piece = Instantiate(asteroidPiecePrefab, transform.position, Quaternion.identity);
            Rigidbody2D pieceRb = piece.GetComponent<Rigidbody2D>();
            pieceRb.velocity = Random.insideUnitCircle * speed;
        }
        Destroy(gameObject);
    }
}
