using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VRInteractableObject_FixedJoint : VRInteractableObject {

    public float breakForce = float.PositiveInfinity;
    VRInput holder;
    public Color highlightedColour;
    Color startColour;
    FixedJoint joint;

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
        if (hand.GetComponent<Rigidbody>() != null)
        {
            if(joint == null)
            {
                joint = this.gameObject.AddComponent<FixedJoint>();
            }
            joint.breakForce = breakForce;
            joint.connectedBody = hand.GetComponent<Rigidbody>();
            holder = hand;
        }
    }

    public override void Released(VRInput hand)
    {
        if(holder == hand)
        {
            Destroy(joint);
            holder = null;
            this.GetComponent<Rigidbody>().AddForce(hand.GetControllerVelocity(), ForceMode.VelocityChange);
        }
    }
}
