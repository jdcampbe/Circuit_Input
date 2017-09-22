using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject_HardCoded : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
