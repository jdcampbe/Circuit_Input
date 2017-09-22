using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerButton_KeyPressed : MonoBehaviour {

    //We can get the component on another object
    public Transform buttonClicker;
    Vector3 clickerStartPosition;

	// Use this for initialization
	void Start () {
        clickerStartPosition = buttonClicker.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveButtonIn();
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            MoveButtonOut();
        }
	}

    void MoveButtonIn()
    {
        //We can change properties on that object
        buttonClicker.position = this.GetComponent<Transform>().position;

    }

    void MoveButtonOut()
    {
        //We can change properties on that object
        buttonClicker.position = clickerStartPosition;

    }

}
