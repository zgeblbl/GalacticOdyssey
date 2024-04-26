using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushBounce : MonoBehaviour
{
    // Start is called before the first frame update
    private CircleCollider2D collider;
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        collider.sharedMaterial.bounciness = 0.7f;
        collider.sharedMaterial.friction = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            collider.sharedMaterial.bounciness = Random.Range(0.7f,1.2f);
            collider.sharedMaterial.friction = Random.Range(0.4f, 0.7f);

        }
    }
}
