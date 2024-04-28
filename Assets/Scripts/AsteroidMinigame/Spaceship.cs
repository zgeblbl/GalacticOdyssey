using UnityEngine;

public class Spaceship : MonoBehaviour
{
    //public float fixedSpeed = 5f;
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
        //transform.Translate(Vector3.down * fixedSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
        {
            
            transform.Translate(Vector3.right * verticalSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            
            transform.Translate(Vector3.left * verticalSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x <= 104f)
        {

            transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x >= -3.5f)
        {
            transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);
        }
        float clampedY = Mathf.Clamp(transform.position.y, minYPosition, maxYPosition);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
