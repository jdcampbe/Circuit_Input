using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : MonoBehaviour {

    public Color newColor; 

	// Use this for initialization
	void Start () {
        //Note that this is the American way of spelling Color (Canadian/British colour is never used)
        this.GetComponent<MeshRenderer>().material.color = newColor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
