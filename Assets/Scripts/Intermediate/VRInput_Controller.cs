using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRInput_Controller : VRInput {


    public XRNode hand;

    public List<VRInteractableObject> heldObjects = new List<VRInteractableObject>();
    public List<VRInteractableObject> activatedObjects = new List<VRInteractableObject>();

    protected string grabAxis = "";
    protected string activateAxis = "";

    // Use this for initialization
    private void Start () {
		if(hand == XRNode.LeftHand)
        {
            activateAxis = "LeftTrigger";
            grabAxis = "LeftGrip";
        }
        else
        {
            activateAxis = "RightTrigger";
            grabAxis = "RightGrip";
        }

	}

    public override Vector3 GetControllerVelocity()
    {
        List<XRNodeState> nodes = new List<XRNodeState>();

        InputTracking.GetNodeStates(nodes);

        foreach(XRNodeState node in nodes)
        {
            if(node.nodeType == hand)
            {
                Vector3 handVelocity = Vector3.zero;

                if(node.TryGetVelocity(out handVelocity))
                {

                    Quaternion rotationFix = Quaternion.FromToRotation(Vector3.forward, this.transform.root.forward);

                    handVelocity = rotationFix * handVelocity;

                    return handVelocity;
                }

            }
        }

        return Vector3.zero;
    }

    
    /*private void FixedUpdate()
    {
        this.transform.localPosition = InputTracking.GetLocalPosition(hand);
        this.transform.localRotation = InputTracking.GetLocalRotation(hand);
    }*/

    private void Update () {

        this.transform.localPosition = InputTracking.GetLocalPosition(hand);
        this.transform.localRotation = InputTracking.GetLocalRotation(hand);

        //Are we holding an object?
        if (heldObjects.Count > 0)
        {
            //Are we releasing the grip?
            if (Input.GetAxis(grabAxis) <= 0.8f)
            {
                ReleaseObjects();
            }
            HandleActivation();
        }
    }


    private void HandleActivation()
    {
        if (Input.GetAxis(activateAxis) >= 0.5f)
        {
            foreach (VRInteractableObject heldObject in heldObjects)
            {
                heldObject.Activated(this);
                activatedObjects.Add(heldObject);
            }
        }
        else
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
        activatedObjects = new List<VRInteractableObject>();
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

            if (Input.GetAxis(grabAxis) >= 0.5f)
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
