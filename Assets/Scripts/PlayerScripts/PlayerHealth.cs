using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health { get; set; }
    private bool invincible;
    private new Renderer renderer;
    public Animator animator;
    public PlayerMovement playerMovement;
    [SerializeField] int sceneCount2;

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
    public IEnumerator TakeDamage(int sceneCount) 
    {
        Debug.Log(invincible);
        if (invincible)
        {
            yield break;
        }

        health -= 1;
        

        if (health == 0)
        {
            TriggerDeath(sceneCount);
        }
        invincible = true;
        Color oldColor = renderer.material.color;
        renderer.material.color = Color.Lerp(oldColor, Color.gray, 1f); // sonra sileriz
        yield return new WaitForSeconds(2);
        invincible = false;
        renderer.material.color = oldColor;

    }
    private void TriggerDeath(int sceneCount)
    {

        //death animation stuff
        //scene gecis
        //Destroy(gameObject);
        //playerMovement.setDeath(true);
        Debug.Log("Death" + sceneCount);
        if (animator != null)
        {
            
            animator.SetBool("isDeath", true);
            animator.SetInteger("DeathOrder", SceneManager.GetActiveScene().buildIndex);
        }
        
        
        
    }
    private void OnParticleCollision(GameObject other)
    {
        StartCoroutine(TakeDamage(0));
    }
    
    public int GetHealth()
    {
        return health;
    }
    public bool Getinvi()
    {
       return invincible;
    }

    void LoadRestartMenu(int sceneCount)
    {
        Debug.Log(sceneCount2 + 4);
        SceneManager.LoadScene(sceneCount2 + 4);
    }



}
