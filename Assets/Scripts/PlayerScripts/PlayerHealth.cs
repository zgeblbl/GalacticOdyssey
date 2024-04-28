using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health { get; set; }
    private bool invincible;
    private new Renderer renderer;
    public Animator animator;
    public PlayerMovement playerMovement;
<<<<<<< Updated upstream
    public Image[] helmets;
    public Image[] brokenHelmets;
    public Image healthHelmet1;
    public Image healthHelmet2;
    public Image healthHelmet3;
    public Image brokenHelmet1;
    public Image brokenHelmet2;
    public Image brokenHelmet3;
=======
    public Image heart1, heart2, heart3;
    public Sprite broken;
>>>>>>> Stashed changes

    // Start is called before the first frame update


    void Start()
    {
        helmets = new Image[] { healthHelmet1, healthHelmet2, healthHelmet3 };
        brokenHelmets = new Image[] { brokenHelmet1, brokenHelmet2, brokenHelmet3 };

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
        helmets[health-1].gameObject.SetActive(false);
        brokenHelmets[health-1].gameObject.SetActive(true);

        health -= 1;
<<<<<<< Updated upstream


        if(health == 0)
=======
        switch (health)
        {
            case 2:
                Debug.Log(health);
                heart3.sprite = broken;
                break;
            case 1:
                heart2.sprite = broken;
                break;
            case 3:
                heart1.sprite = broken;
                break;
        }
        if (health == 0)
>>>>>>> Stashed changes
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
        
        animator.SetBool("isDeath", true);
        LoadRestartMenu(sceneCount);
        
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
        Debug.Log(sceneCount);
        SceneManager.LoadScene(sceneCount);
    }



}
