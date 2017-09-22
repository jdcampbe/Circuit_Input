using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject_Once : MonoBehaviour {

    public Vector3 moveObjectByAmount;

	// Use this for initialization
	void Start () {
        SpawnObject();
    }
	
	// Update is called once per frame
	void Update () {
      
	}

    public void SpawnObject()
    {
        this.GetComponent<Transform>().position = this.GetComponent<Transform>().position + moveObjectByAmount;
    }
}
