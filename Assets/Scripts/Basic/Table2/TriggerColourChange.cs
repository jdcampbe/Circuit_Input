using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColourChange : MonoBehaviour {

    public Color newColor;

    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<MeshRenderer>().material.color = newColor;
    }

}
