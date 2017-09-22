using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerButton_Trigger : MonoBehaviour {

    public KeyCode activationButton = KeyCode.JoystickButton1;

    //We can get the component on another object
    public Transform buttonClicker;
    Vector3 clickerStartPosition;

	// Use this for initialization
	void Start () {
        clickerStartPosition = buttonClicker.position;
	}

    private void Update()
    {
        if (Input.GetKeyUp(activationButton))
        {
            MoveButtonOut();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "VRInput")
        {
            if (Input.GetKeyDown(activationButton))
            {
                MoveButtonIn();
            }
        }
    }

    public void MoveButtonIn()
    {
        //We can change properties on that object
        buttonClicker.position = this.GetComponent<Transform>().position;

    }

    public void MoveButtonOut()
    {
        //We can change properties on that object
        buttonClicker.position = clickerStartPosition;

    }

}
