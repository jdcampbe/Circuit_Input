using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class VRController_Classic : VRController
{
    
    [System.Serializable]
    public struct AxisButton
    {
       public bool isDown { get { return isDown; }set{ previousDownState = isDown;isDown = value;} }
       private bool previousDownState;
       public bool pressedDown { get { if (isDown && !previousDownState) { return true; } else { return false; } } }
       public bool pressedUp { get { if (!isDown && previousDownState) { return true; } else { return false; } } }
       public string axisName;
       public float triggerPoint;
       public float releasePoint;

        public void UpdateAxis()
        {
            if (Input.GetAxis(axisName) <= releasePoint)
            {
                isDown = false;
            }
            if (Input.GetAxis(axisName) >= triggerPoint)
            {
                isDown = true;
            }
        }
    }

    [SerializeField]
    public AxisButton grabButton;
    [SerializeField]
    public AxisButton releaseButton;
    
    private void UpdateControllers()
    {
        grabButton.UpdateAxis();
        releaseButton.UpdateAxis();
    }
    

    
}
