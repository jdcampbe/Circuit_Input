using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class VRButton_Base : ScriptableObject{

    public string buttonName = "";
    private bool mIsDown = false;
    public bool isDown { get { return mIsDown; }
        set {
            previousDownState = mIsDown;
            mIsDown = value;
            if (value)
            {
                if (pressedDown)
                {
                    Debug.Log("Button Down:" + buttonName);
                }
                if (ButtonDown != null && pressedDown)
                {
                    ButtonDown.Invoke();
                }
                if (ButtonHeldDown != null)
                {
                    ButtonHeldDown.Invoke();
                }
            }
            else
            {
                if (pressedUp)
                {
                    Debug.Log("Button Up:" + buttonName);
                }
                if (ButtonUp != null && pressedUp)
                {
                    ButtonUp.Invoke();
                }
                if (ButtonHeldUp != null)
                {
                    ButtonHeldUp.Invoke();
                }
            }
        } }
    protected bool previousDownState;
    public bool pressedDown { get { if (isDown && !previousDownState) { return true; } else { return false; } } }
    public bool pressedUp { get { if (!isDown && previousDownState) { return true; } else { return false; } } }

    //public delegate void ButtonDelegate(string buttonName);
    public UnityEvent ButtonDown;
    public UnityEvent ButtonUp;
    public UnityEvent ButtonHeldDown;
    public UnityEvent ButtonHeldUp;

    public virtual void UpdateAxis()
    {
        
    }
}
