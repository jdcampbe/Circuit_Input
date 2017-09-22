using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class VRController_Classic : VRController
{

    [SerializeField]
    private List<VRButton_Base> buttonsUsed = new List<VRButton_Base>();

    private Dictionary<string, VRButton_Base> librariedButtons = new Dictionary<string, VRButton_Base>();

    private void Start()
    {
        foreach(VRButton_Base button in buttonsUsed)
        {
            if (!librariedButtons.ContainsKey(button.buttonName)) {
                librariedButtons.Add(button.buttonName, button);
            }
        }
    }

    public override void UpdateButtons()
    {
        foreach(VRButton_Base button in buttonsUsed)
        {
            button.UpdateAxis();
        }
    }
    
    public VRButton_Base GetButton(string buttonName)
    {
        if (librariedButtons.ContainsKey(buttonName))
        {
            return librariedButtons[buttonName];
        }
        else
        {
            Debug.LogError("Failed to find button " + buttonName + " on object " + this.gameObject.name);
            return new VRButton_Base();
        }
    }
    
}
