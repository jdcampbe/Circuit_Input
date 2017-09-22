using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject moveObjectPrefab;

	// Use this for initialization
	void Start () {
        SpawnObject();
	}

    public void SpawnObject()
    {
        Instantiate(moveObjectPrefab, this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
    }
}
