using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerButton_AxisActivateSound : MonoBehaviour
{

    public string axisName = "RightTrigger";
    public Spawner spawner;

    //We can get the component on another object
    public Transform buttonClicker;
    Vector3 clickerStartPosition;
    bool buttonReleased = true;

    // Use this for initialization
    void Start()
    {
        clickerStartPosition = buttonClicker.localPosition;
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
        if (buttonReleased) { 
            this.GetComponent<AudioSource>().Play();
            spawner.SpawnObject();
            buttonReleased = false;
        }
    }

    public void MoveButtonOut()
    {
        //We can change properties on that object
        buttonClicker.localPosition = clickerStartPosition;
        buttonReleased = true;
    }

}
