using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OptionMenuController : MonoBehaviour
{
    public Toggle Slow, Normal, Fast, Forward, Backward;
    private GameObject coaster;
    private MovingCart script;

    // Start is called before the first frame update
    void Start()
    {
        coaster = GameObject.Find("Rollercoaster");
        script = coaster.GetComponent<MovingCart>();
    }

    // Update is called once per frame
    void Update()
    {
        Speed();
        Direction();
    }

    public void Speed()
    {
        if(Slow.isOn)
        {
            script.movingSpeed = 20;
        }
        else if (Normal.isOn)
        {
            script.movingSpeed = 30;
        }
        else if (Fast.isOn)
        {
            script.movingSpeed = 40;
        }
    }

    public void Direction()
    {
      
        if (Forward.isOn)
        {
            script.reverse = false;
        }
        else if(Backward.isOn)
        {
            script.reverse = true;
        }
    }
}
