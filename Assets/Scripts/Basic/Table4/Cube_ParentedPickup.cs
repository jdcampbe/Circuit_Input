using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_ParentedPickup : MonoBehaviour {

    public string axisName = "RightTrigger";

    public void Update()
    {
        if (Input.GetAxis(axisName) < 0.5f)
        {
            DropCube();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "VRInput")
        {
            if (Input.GetAxis(axisName) >= 0.5f)
            {
                PickUpCube(other.transform);
            }
        }
    }

    //When we call this function, we require that whatever code calls the function provide 
    //a Transform that we can use to parent to.
    public void PickUpCube(Transform objectPickingUpTheCube)
    {
        //We can the cubes place in the ehiarchy so it's a child of the object picking up the cube
        //notice now that we use this.transform instead of this.GetComponent<Transform>() because
        //unity already stores a refernace to the transform we can use.
        this.transform.parent = objectPickingUpTheCube;
    }

    public void DropCube()
    {
        //We can change properties on that object
        this.transform.parent = null;

    }
}
