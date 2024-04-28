using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour,IWindAffected
{
    public Animator animator;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 18f;
    [SerializeField] float gravityScale = 5f;
    [SerializeField] float descendForce = 10f; 

    private Rigidbody2D rb;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isDescending;
    [SerializeField] bool isDeath = false;

    [SerializeField] int coinCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.gravityScale = gravityScale; 
    }

    void Update()
    {   
        // Grounded check
        if (rb.velocity.y == 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

       transform.position = new Vector3(transform.position.x, transform.position.y, 0f); // Keep player on the same z-axis
        // Movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("xVelocity", Mathf.Abs(horizontalInput));
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Flip character sprite horizontally
        }
        // Flip character sprite back to original orientation if moving right
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Set character sprite to original orientation
        }

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        animator.SetFloat("yVelocity", rb.velocity.y);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isJumping", true);
            //StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.15f, 1f));
        }
        else if (Input.GetButton("Jump") && rb.velocity.y > 0) // Holding jump button
        {
            rb.gravityScale = gravityScale / 2;
        }
        else // Release jump button
        {
            rb.gravityScale = gravityScale;
        }

        // Descending
        if (Input.GetKey(KeyCode.S))
        {
            isDescending = true;
            rb.velocity = new Vector2(rb.velocity.x, -descendForce);
        }
        else if (isDescending)
        {
            isDescending = false;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if player is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    public void ApplyWind(float windPower)
    {
        transform.position += new Vector3(windPower, 0f, 0f);
    }

    public void coinCollected()
    {
        coinCount++;
    }

    public void setDeath(bool isDead)
    {
        isDeath = isDead;
    }
}
