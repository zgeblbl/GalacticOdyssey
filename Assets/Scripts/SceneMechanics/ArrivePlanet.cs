using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrivePlanet : MonoBehaviour
{
    void Arrive()
    {
        if(SceneManager.GetActiveScene().buildIndex != 5){ SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
        else
        {
            SceneManager.LoadScene(10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Arrive();
        }
    }
}
