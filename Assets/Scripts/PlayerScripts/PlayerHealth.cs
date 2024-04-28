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
    Transform cameraTransform;

    // Start is called before the first frame update


    void Start()
    {

        health = 3;
        invincible = false;
        renderer = GetComponent<Renderer>();
        cameraTransform = Camera.main.transform;
        
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
            FocusChar();
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
        StartCoroutine(TakeDamage(1));
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
    void FocusChar(){
        Vector3 velocity = Vector3.zero;
        float smoothTime = 0.25f;
        cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, new Vector3(transform.position.x, transform.position.y, cameraTransform.position.z), ref velocity, smoothTime);
    }


}
