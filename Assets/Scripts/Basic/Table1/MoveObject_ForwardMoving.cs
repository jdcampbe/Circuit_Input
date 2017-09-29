using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject_ForwardMoving : MonoBehaviour {

    public float speed = 2f;
    public float lifeTime = 2f;

    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, lifeTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.GetComponent<Transform>().position = this.GetComponent<Transform>().position + this.GetComponent<Transform>().forward * speed * Time.deltaTime;
    }
}
