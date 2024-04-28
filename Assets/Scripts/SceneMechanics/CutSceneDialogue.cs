using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutSceneDialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    private int index;
    public float textSpeed;
    public GameObject image;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            } 
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            if(index == 1)
            {
                image.SetActive(false);
            }
            index++;
            textComponent.text += string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (SceneManager.GetActiveScene().buildIndex == 1){ 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
            }
            else
            {
                textComponent.text = string.Empty;
            }
        }
    }
}
