using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public int score = 0;
    public Image[] hearts;
    public GameObject pauseScreen;
    GameObject player;
    GameObject interfaceObj;
    public Sprite[] heartSprites;
    
    int health;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        interfaceObj = GameObject.FindWithTag("Interface");
        
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<PlayerHealth>().GetHealth();
        if (health == 3)
        {
            hearts[0].sprite = heartSprites[0];
            hearts[1].sprite = heartSprites[0];
            hearts[2].sprite = heartSprites[0];
        }
        else if (health == 2)
        {
            hearts[0].sprite = heartSprites[0];
            hearts[1].sprite = heartSprites[0];
            hearts[2].sprite = heartSprites[1];
        }
        else if (health == 1)
        {
            hearts[0].sprite = heartSprites[0];
            hearts[1].sprite = heartSprites[1];
            hearts[2].sprite = heartSprites[1];
        }
        else
        {
            hearts[0].sprite = heartSprites[1];
            hearts[1].sprite = heartSprites[1];
            hearts[2].sprite = heartSprites[1];
        }
    }
}
