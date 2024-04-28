using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject pauseScreen;
    GameObject player;
    int health;

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    public void Options(){
        SceneManager.LoadScene("Options");
    }
    // Start is called before the first frame update
    void Start()
    {
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<PlayerHealth>().GetHealth();
        if (health == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            
        }
        else if (health == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
            
        }
        else if (health == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
