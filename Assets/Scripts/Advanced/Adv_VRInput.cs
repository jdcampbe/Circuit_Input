using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adv_VRInput : MonoBehaviour {
    protected List<VRInteractableObject> heldObjects = new List<VRInteractableObject>();
    protected List<VRInteractableObject> activatedObjects = new List<VRInteractableObject>();

    public virtual Vector3 GetControllerVelocity()
    {
        return Vector3.zero;
    }
	
}
