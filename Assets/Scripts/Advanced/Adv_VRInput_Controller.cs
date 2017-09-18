using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(VRController_Classic))]
public class Adv_VRInput_Controller : VRInput {


    protected List<VRInteractableObject> heldObjects = new List<VRInteractableObject>();
    protected List<VRInteractableObject> activatedObjects = new List<VRInteractableObject>();

    VRController_Classic controller;

    [SerializeField]
    protected string grabAxis = "";
    [SerializeField]
    protected string activateAxis = "";

    private void Start()
    {
        controller = this.GetComponent<VRController_Classic>();
    }

    public override Vector3 GetControllerVelocity()
    {
        return controller.GetControllerVelocity();
    }

    
    private void FixedUpdate()
    {
        if (controller.useFixedUpdate)
        {
            //Are we releasing the grip?
            if (controller.GetButton(grabAxis).pressedUp)
            {
                ReleaseObjects();
            }
            HandleActivation();
        }
    }

    private void Update () {

        //Are we holding an object?
        if (heldObjects.Count > 0)
        {
            if (controller.GetButton(grabAxis).pressedUp)
            {
                ReleaseObjects();
            }
            HandleActivation();
        }
    }


    private void HandleActivation()
    {
        if (controller.GetButton(activateAxis).pressedDown)
        {
            foreach (VRInteractableObject heldObject in heldObjects)
            {
                heldObject.Activated(this);
                activatedObjects.Add(heldObject);
            }
        }
        else if(controller.GetButton(activateAxis).pressedUp)
        {
            DeactivateObjects();
        }
    }

    void ReleaseObjects()
    {
        foreach (VRInteractableObject heldObject in heldObjects)
        {
            heldObject.Released(this);
        }
        heldObjects = new List<VRInteractableObject>();
    }

    void DeactivateObjects()
    {
        foreach (VRInteractableObject activatedObject in activatedObjects)
        {
            activatedObject.Deactivated(this);
        }
        activatedObjects = null;
    }

    private void OnTriggerEnter(Collider colliderEntered)
    {
        VRInteractableObject objectInRange = colliderEntered.GetComponent<VRInteractableObject>();

        if (objectInRange != null)
        {
            objectInRange.Highlighted(this);
        }
    }

    private void OnTriggerStay(Collider overlappingCollider)
    {
        VRInteractableObject objectInRange = overlappingCollider.GetComponent<VRInteractableObject>();

        if (objectInRange != null)
        {

            if (controller.GetButton(grabAxis).pressedDown)
            {
                if (!heldObjects.Contains(objectInRange))
                {
                    heldObjects.Add(objectInRange);
                    objectInRange.Grabbed(this);
                }

            }
        }
    }

    private void OnTriggerExit(Collider colliderExiting)
    {
        VRInteractableObject objectLeaving = colliderExiting.GetComponent<VRInteractableObject>();

        if (objectLeaving != null)
        {
            objectLeaving.Unhighlighted(this);
        }
    }


}
