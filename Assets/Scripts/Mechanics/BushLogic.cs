using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BushLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private new CircleCollider2D collider;
    private int collisionCounter;
    private readonly int collisionLimit = 5;
    private Rigidbody2D rb;

    void Start()
    {
        
        collider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        collider.sharedMaterial.bounciness = 0.7f;
        collider.sharedMaterial.friction = 0.4f;
        collisionCounter = 0;
    }

    // Update is called once per frame
    void DestroyGameObject()
    {
        Destroy(gameObject); // Destroy the game object after the delay
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collisionCounter == collisionLimit)
        {
            //Oncesinde belki yok olma animasyonu yaparýz
            animator.SetBool("destroy",true);
            Invoke("DestroyGameObject", 0.4f);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            
            StartCoroutine(collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(9));
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            collisionCounter++;
            collider.sharedMaterial.bounciness = Random.Range(0.7f,1.2f);
            collider.sharedMaterial.friction = Random.Range(0.4f, 0.7f);
        }

    }

    
}
