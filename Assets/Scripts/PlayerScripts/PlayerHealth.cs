using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health { get; set; }
    private bool invincible;
    private new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        invincible = false;
        renderer = GetComponent<Renderer>();
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
        Color oldColor = renderer.material.color;
        renderer.material.color = Color.Lerp(oldColor, Color.gray, 1f); // sonra sileriz
        yield return new WaitForSeconds(2);
        invincible = false;
        renderer.material.color = oldColor;

    }
    private void TriggerDeath()
    {
        //death animation stuff
        //scene gecis
        Destroy(gameObject);
        SceneManager.LoadScene(1); 
    }
    private void OnParticleCollision(GameObject other)
    {
        StartCoroutine(TakeDamage());
    }


}
