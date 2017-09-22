using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject_Variable : MonoBehaviour {

    public Vector3 startingScale;

	// Use this for initialization
	void Start () {
        this.GetComponent<Transform>().localScale = startingScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
