using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("asda");
        if (collision.name == "Player")
        {
            print("asda");
            collision.gameObject.GetComponent <PlayerMovement>().coinCollected();
            Destroy(gameObject);
        }
    }
}
