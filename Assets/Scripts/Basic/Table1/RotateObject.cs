using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    public Vector3 startingRotation;

	// Use this for initialization
	void Start () {
        //Note that in the editor we use what are called "Euler Angles" (pronounced "oiler").
        //Unity converts Euler Angles into Quaternions to avoid a problem called "Gimbal Lock" 
        //which is when axises align causing an issue when trying to rotate.

        //Long story short, we have to use Quaternion.Euler() to convert our rotation into unity's interpretation.
        this.GetComponent<Transform>().rotation = Quaternion.Euler(startingRotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
