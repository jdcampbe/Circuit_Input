using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class VRController : MonoBehaviour
{
    public XRNode hand;
    

    [SerializeField]
    public bool useFixedUpdate = false;

    [SerializeField]
    protected bool trackPosition = false;



    public virtual Vector3 GetControllerVelocity()
    {
        List<XRNodeState> nodes = new List<XRNodeState>();

        InputTracking.GetNodeStates(nodes);

        foreach (XRNodeState node in nodes)
        {
            if (node.nodeType == hand)
            {
                Vector3 handVelocity = Vector3.zero;

                if (node.TryGetVelocity(out handVelocity))
                {

                    Quaternion rotationFix = Quaternion.FromToRotation(Vector3.forward, this.transform.root.forward);

                    handVelocity = rotationFix * handVelocity;

                    return handVelocity;
                }

            }
        }

        return Vector3.zero;
    }
    
    private void FixedUpdate()
    {
        if (useFixedUpdate)
        {
            UpdateButtons();
            if(trackPosition)
                PositionController();
        }
    }

    private void Update()
    {
        if (!useFixedUpdate)
        {
            UpdateButtons();
            if(trackPosition)
                PositionController();
        }
    }
    
    protected void PositionController()
    {
        this.transform.localPosition = InputTracking.GetLocalPosition(hand);
        this.transform.localRotation = InputTracking.GetLocalRotation(hand);
    }

    
    protected void UpdateButtons()
    {

    }

}
