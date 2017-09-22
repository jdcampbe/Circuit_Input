using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject_ConstantlySmoothed : MonoBehaviour {

    public Vector3 moveObjectByAmount;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.GetComponent<Transform>().position = this.GetComponent<Transform>().position + moveObjectByAmount * Time.deltaTime;
    }
}
