using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInteractableObject_Gun : VRInteractableObject {

    public GameObject bulletPrefab;
    public Transform handlePoint;
    public Transform firingPoint;
    public MeshRenderer highlightedPart;
    VRInput holder;
    public Color highlightedColour;
    Color startColour;

    bool firing = false;

    private void Start()
    {
        //Intermediate verify meshrenderer exists
        startColour = highlightedPart.material.color;
    }

    public override void Highlighted(VRInput hand)
    {
        //Intermediate verify meshrenderer exists
        //Advanced handle all renderes and have static setting for highlight colour
        highlightedPart.material.color = highlightedColour;
    }

    public override void Unhighlighted(VRInput hand)
    {
        //Intermediate verify meshrenderer exists
        //Advanced handle all renderes and have static setting for highlight colour
        highlightedPart.material.color = startColour;
    }

    public override void Grabbed(VRInput hand)
    {
        if (this.GetComponent<Rigidbody>())
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
        holder = hand;
        this.transform.position = holder.transform.position+(this.transform.position - handlePoint.position);
        this.transform.rotation = holder.transform.rotation * Quaternion.FromToRotation(handlePoint.forward, this.transform.forward);
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

    public override void Activated(VRInput hand)
    {
        if (!firing)
        {
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        }
    }

    public override void Deactivated(VRInput hand)
    {
        firing = false;
    }
}
