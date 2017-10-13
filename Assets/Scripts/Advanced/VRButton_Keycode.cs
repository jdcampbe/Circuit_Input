using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "VRButton_KeyCode", menuName = "CircuitStream/Keycode", order = 1)]
public class VRButton_Keycode:VRButton_Base {
    
    public KeyCode keycode;

    public override void UpdateAxis()
    {
        if (!Input.GetKey(keycode))
        {
            isDown = false;
            
        }
        else
        {
            isDown = true;
        }
    }
}
