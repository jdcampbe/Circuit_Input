using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject_ForwardMoving : MonoBehaviour {

    public float speed = 1f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.GetComponent<Transform>().position = this.GetComponent<Transform>().position + this.GetComponent<Transform>().forward * speed * Time.deltaTime;
    }
}
