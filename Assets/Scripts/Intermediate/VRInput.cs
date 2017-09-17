using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInput : MonoBehaviour {

    public virtual Vector3 GetControllerVelocity()
    {
        return Vector3.zero;
    }
	
}
