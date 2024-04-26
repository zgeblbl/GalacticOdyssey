using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health { get; set; }
    private bool invincible;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator TakeDamage() 
    {
        if (invincible)
        {
            yield break;
        }
        health -= 1;
        if(health == 0)
        {
            TriggerDeath();
        }
        invincible = true;
        yield return new WaitForSeconds(1);
        invincible = false;

    }
    private void TriggerDeath()
    {
        //death animation stuff
        //scene gecis
        Destroy(gameObject);
        SceneManager.LoadScene(1); 
    }
    
    
}
