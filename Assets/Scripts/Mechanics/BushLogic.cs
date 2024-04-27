using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BushLogic : MonoBehaviour,IWindAffected
{
    // Start is called before the first frame update
    
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
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collisionCounter == collisionLimit)
        {
            //Oncesinde belki yok olma animasyonu yaparýz
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            
            StartCoroutine(collision.gameObject.GetComponent<PlayerHealth>().TakeDamage());
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            collisionCounter++;
            collider.sharedMaterial.bounciness = Random.Range(0.7f,1.2f);
            collider.sharedMaterial.friction = Random.Range(0.4f, 0.7f);
        }

    }

    public void ApplyWind(float windPower)
    {
        rb.AddForce(new Vector2(windPower, 0));
    }
}
