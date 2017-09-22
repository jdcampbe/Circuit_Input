using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour {

    public GameObject moveObjectPrefab;
    public float spawnRate;
    float lastSpawnTime;


    void Update()
    {
        if(lastSpawnTime + spawnRate < Time.time)
        {
            SpawnObject();
            lastSpawnTime = Time.time;
        }
    }


    public void SpawnObject()
    {
        Instantiate(moveObjectPrefab, this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
    }
}
