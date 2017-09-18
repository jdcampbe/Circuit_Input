using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInteractableObject_Parented : VRInteractableObject {

    VRInput holder;
    public Color highlightedColour;
    Color startColour;

    private void Start()
    {
        //Intermediate verify meshrenderer exists
        startColour = this.GetComponent<MeshRenderer>().material.color;
    }

    public override void Highlighted(VRInput hand)
    {
        //Intermediate verify meshrenderer exists
        //Advanced handle all renderes and have static setting for highlight colour
        this.GetComponent<MeshRenderer>().material.color = highlightedColour;
    }

    public override void Unhighlighted(VRInput hand)
    {
        //Intermediate verify meshrenderer exists
        //Advanced handle all renderes and have static setting for highlight colour
        this.GetComponent<MeshRenderer>().material.color = startColour;
    }

    public override void Grabbed(VRInput hand)
    {
        if (this.GetComponent<Rigidbody>())
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
        holder = hand;
        this.transform.parent = holder.transform;
    }

    public override void Released(VRInput hand)
    {
        if(holder == hand)
        {
            if (this.GetComponent<Rigidbody>())
            {
                this.GetComponent<Rigidbody>().isKinematic = false;
            }
            holder = null;
            this.transform.parent = null;
        }
    }
}
