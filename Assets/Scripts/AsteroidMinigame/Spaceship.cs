using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float fixedSpeed = 5f;
    public float verticalSpeed = 10f;
    private Rigidbody2D rb;
    public float maxYPosition = 4.5f; // Maximum y position
    public float minYPosition = -4.5f; // Minimum y position

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        transform.Translate(Vector3.down * fixedSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            // Move the spaceship up
            transform.Translate(Vector3.right * verticalSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            // Move the spaceship down
            transform.Translate(Vector3.left * verticalSpeed * Time.deltaTime);
        }

        // Clamp the spaceship's position within minYPosition and maxYPosition
        float clampedY = Mathf.Clamp(transform.position.y, minYPosition, maxYPosition);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
