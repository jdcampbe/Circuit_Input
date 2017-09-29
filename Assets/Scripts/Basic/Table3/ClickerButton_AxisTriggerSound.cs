﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerButton_AxisTriggerSound : MonoBehaviour
{

    public string axisName = "RightTrigger";

    //We can get the component on another object
    public Transform buttonClicker;
    Vector3 clickerStartPosition;
    bool buttonReleased = true;

    // Use this for initialization
    void Start()
    {
        clickerStartPosition = buttonClicker.position;
    }

    private void Update()
    {
        if (Input.GetAxis(axisName) < 0.5f)
        {
            MoveButtonOut();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "VRInput")
        {
            if (Input.GetAxis(axisName) >= 0.5f)
            {
                MoveButtonIn();
            }
        }
    }

    public void MoveButtonIn()
    {
        //We can change properties on that object
        buttonClicker.position = this.GetComponent<Transform>().position;
        if(buttonReleased)
        {
            this.GetComponent<AudioSource>().Play();
            buttonReleased = false;
        }
    }

    public void MoveButtonOut()
    {
        //We can change properties on that object
        buttonClicker.position = clickerStartPosition;
        buttonReleased = true;
    }

}