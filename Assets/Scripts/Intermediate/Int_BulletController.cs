using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Int_BulletController : MonoBehaviour {

    public float bulletForce = 15f;
    public float bulletLife = 3f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(this.transform.forward * bulletForce, ForceMode.Impulse);
        Destroy(this.gameObject, bulletLife);
	}
}
