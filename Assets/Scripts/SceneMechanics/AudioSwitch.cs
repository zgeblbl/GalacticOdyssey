using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitch : MonoBehaviour
{
    public GameObject slider;
    bool isSwitchedOn = false;

    public void ClickOption()
    {
        isSwitchedOn = isSwitchedOn!;
        slider.SetActive(isSwitchedOn);
    }
}
