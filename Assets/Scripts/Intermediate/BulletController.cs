using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;

    public void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void Update () {
        this.transform.position += this.transform.forward * Time.deltaTime * speed;
	}
}
