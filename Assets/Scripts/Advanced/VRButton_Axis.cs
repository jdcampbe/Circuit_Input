using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VRButton_Axis", menuName = "CircuitStream/Axis", order = 2)]
public class VRButton_Axis:VRButton_Base {
    
    public string axisName;
    public float triggerPoint;
    public float releasePoint;

    public override void UpdateAxis()
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
