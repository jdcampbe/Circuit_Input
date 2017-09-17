using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInteractableObject : MonoBehaviour {

   
	public virtual void Highlighted(VRInput hand)
    {
        Debug.Log("Highlighted:" + gameObject.name);
    }

    public virtual void Unhighlighted(VRInput hand)
    {
        Debug.Log("Unhighlighted:" + gameObject.name);
    }

    public virtual void Grabbed(VRInput hand)
    {
        Debug.Log("Grabbed:" + gameObject.name);
    }

    public virtual void Released(VRInput hand)
    {
        Debug.Log("Released:" + gameObject.name);
    }

    public virtual void Activated(VRInput hand)
    {
        Debug.Log("Activated:" + gameObject.name);
    }
    public virtual void Deactivated(VRInput hand)
    {
        Debug.Log("Deactivated:" + gameObject.name);
    }

}
