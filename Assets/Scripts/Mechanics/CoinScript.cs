using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int coinVal = 5;
    private UIHandler handler;
    private AudioManager audioManager;
    private void Start()
    {
        handler = FindObjectOfType<UIHandler>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            audioManager.CoinEffect();
            handler.score += coinVal;
            collision.gameObject.GetComponent <PlayerMovement>().coinCollected();
            gameObject.GetComponentInParent<CoinParent>().destroy();
            
        }
    }
}
