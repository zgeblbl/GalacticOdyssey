using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    [SerializeField] int sceneCount;
    public void Respawn()
    {
        SceneManager.LoadScene(sceneCount);
    }
}
