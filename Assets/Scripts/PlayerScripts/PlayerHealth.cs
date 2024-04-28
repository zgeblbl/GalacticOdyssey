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
    public Image[] helmets;
    public Image[] brokenHelmets;
    public Image healthHelmet1;
    public Image healthHelmet2;
    public Image healthHelmet3;
    public Image brokenHelmet1;
    public Image brokenHelmet2;
    public Image brokenHelmet3;

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


        if(health == 0)
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
        if (animator != null) animator.SetBool("isDeath", true);
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
        Debug.Log(sceneCount2 + 4);
        SceneManager.LoadScene(sceneCount2 + 4);
    }



}
