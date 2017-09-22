using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VRInteractableObject_PhysicsFollow : VRInteractableObject {
    
    VRInput holder;
    Transform target;
    public Color highlightedColour;
    Color startColour;
    Rigidbody rb;
    bool? gravityStatePriorToPickup;


    private void Start()
    {
        //Intermediate verify meshrenderer exists
        startColour = this.GetComponent<MeshRenderer>().material.color;
        rb = this.GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if(target != null)
        {
            rb.MovePosition(target.position);
            rb.MoveRotation(target.rotation);
        }
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
            if (gravityStatePriorToPickup == null)
            {
                gravityStatePriorToPickup = rb.useGravity;
            }
            if(target == null)
            {
                target = (new GameObject()).transform;
                target.parent = hand.transform;
            }
            target.position = this.transform.position;
            target.rotation = this.transform.rotation;
            rb.useGravity = false;
            holder = hand;
        }
    }

    public override void Released(VRInput hand)
    {
        if(holder == hand)
        {
            Destroy(target.gameObject);
            rb.useGravity = (bool)gravityStatePriorToPickup;
            holder = null;
            rb.AddForce(hand.GetControllerVelocity(), ForceMode.VelocityChange);
        }
    }
}
