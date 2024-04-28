using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] int coinVal = 5;
    UIHandler handler;
    private void Start()
    {
        handler = FindObjectOfType<UIHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            handler.score += coinVal;
            collision.gameObject.GetComponent <PlayerMovement>().coinCollected();
            gameObject.GetComponentInParent<CoinParent>().destroy();
         
        }
    }
}
