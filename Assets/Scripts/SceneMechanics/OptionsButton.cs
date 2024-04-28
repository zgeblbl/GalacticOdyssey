using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public GameObject slider;
    bool switchOn = false;
    public void Options()
    {
        switchOn = !switchOn;
        slider.SetActive(switchOn);
    }
}
