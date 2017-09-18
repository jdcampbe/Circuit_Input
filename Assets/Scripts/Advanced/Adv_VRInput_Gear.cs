using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Adv_VRInput_Gear : VRInput {

    protected List<VRInteractableObject> heldObjects = new List<VRInteractableObject>();
    protected List<VRInteractableObject> activatedObjects = new List<VRInteractableObject>();

    public VRInteractableObject lookedAtObject = null;

    private VRInteractableObject heldObject = null;

    public GameObject reticlePrefab;

    Transform reticle;

    public float maxInteractionDistance = 10f;


    private void Start()
    {
        //Generate the reticle as a copy of our reticle prefab
        //we aren't posititioning the new reticle because it will be repositioned later.
        GameObject instantiatedReticle = Instantiate(reticlePrefab) as GameObject;
        //assign the new reticle to our reticle variable
        reticle = instantiatedReticle.transform;
    }

    // Update is called once per frame
    void FixedUpdate () {

        //Draw a line in the editor so that we can see where the reticle is aiming
        Debug.DrawLine(this.transform.position, this.transform.position + this.transform.forward * maxInteractionDistance, Color.red);


        HandleHighlightingObject();

        HandleGrabbingObject();

        PositionReticle();

	}

    void HandleHighlightingObject()
    {
        RaycastHit hitInformation = new RaycastHit();

        //Check to see if there are any objects in the forward direction of our head
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInformation, maxInteractionDistance))
        {
            Debug.Log(this.gameObject.name + " raycast hit:" + hitInformation.transform.name);

            //Are we already looking at an object? Is the new object different than the one we are looking at? 
            if (lookedAtObject != null && lookedAtObject.transform != hitInformation.transform)
            {
                //Reset to looking at nothing
                lookedAtObject.Unhighlighted(this);
                lookedAtObject = null;
            }

            //If we aren't looking at an object and the object we're looking at is interactable
            if (lookedAtObject == null && hitInformation.transform.GetComponent<VRInteractableObject>() != null)
            {
                //Highlight the object and add it to the objects we are currently looking at
                hitInformation.transform.GetComponent<VRInteractableObject>().Highlighted(this);
                lookedAtObject = hitInformation.transform.GetComponent<VRInteractableObject>();
            }

        }
        //Do we think we're looking at an object, but our raycast says we can't see anything
        else if (lookedAtObject != null)
        {
            //Reset to looking at nothing
            lookedAtObject.Unhighlighted(this);
            lookedAtObject = null;
        }
    }

    void HandleGrabbingObject()
    {
        if (lookedAtObject != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("grabbed");
                lookedAtObject.Grabbed(this);
                heldObject = lookedAtObject;
            }
        }

        if (heldObject != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                heldObject.Released(this);
                heldObject = null;
            }
        }
    }

    void PositionReticle()
    {

        RaycastHit reticleHitInformation = new RaycastHit();

        

        if (Physics.Raycast(this.transform.position, this.transform.forward, out reticleHitInformation, maxInteractionDistance))
        {
            reticle.position = reticleHitInformation.point;

        }else
        {
            reticle.position = this.transform.position + this.transform.forward * maxInteractionDistance;
        }
    }

}
