using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BushLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private CircleCollider2D collider;
    private int collisionCounter;
    private readonly int collisionLimit = 5;
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        collider.sharedMaterial.bounciness = 0.7f;
        collider.sharedMaterial.friction = 0.4f;
        collisionCounter = 0;
    }

    // Update is called once per frame
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collisionCounter);
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
}
