using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButton_Base : ScriptableObject{

    public string buttonName = "";
    private bool mIsDown = false;
    public bool isDown { get { return mIsDown; } set { previousDownState = mIsDown; mIsDown = value; } }
    protected bool previousDownState;
    public bool pressedDown { get { if (isDown && !previousDownState) { return true; } else { return false; } } }
    public bool pressedUp { get { if (!isDown && previousDownState) { return true; } else { return false; } } }

    public virtual void UpdateAxis()
    {
        
    }
}
