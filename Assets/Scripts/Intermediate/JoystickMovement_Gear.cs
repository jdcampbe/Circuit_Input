using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement_Gear : MonoBehaviour
{

    public Transform head;

    public bool isRotateMode = true;

    public float movementSpeed = 3f;
    public float rotationSpeed = 180f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRotateMode)
        {
            RotateLeftOrRight();
        }
        else
        {
            StrafeLeftOrRight();
        }
        MoveBackwardOrForward();

    }

    private void RotateLeftOrRight()
    {
#if UNITY_EDITOR
        //Computer
        //this.transform.RotateAround(head.position, Vector3.up, rotationSpeed * Time.deltaTime * Input.GetAxis("LeftRightComputer"));
        this.transform.RotateAround(head.position, Vector3.up, rotationSpeed * Time.deltaTime * Input.GetAxis("RightJoystickX"));
#else
    //Oculus Rift
    //this.transform.RotateAround(head.position, Vector3.up, rotationSpeed * Time.deltaTime * Input.GetAxis("RightJoystickX"));
     //GearVR
    //this.transform.RotateAround(head.position, Vector3.up, rotationSpeed * Time.deltaTime * Input.GetAxis("Oculus_GearVR_LThumbstickX"));
#endif

        //this.transform.RotateAround(head.position, Vector3.up, rotationSpeed * Time.deltaTime * Input.GetAxis("RightJoystickX"));
        //this.transform.RotateAround(head.position, Vector3.up, rotationSpeed * Time.deltaTime * Input.GetAxis("Oculus_GearVR_LThumbstickX"));
    }


    private void StrafeLeftOrRight()
    {
        //this.transform.position +=
        //    (new Vector3(head.right.x, 0f, head.right.z)).normalized *
        //    movementSpeed * Time.deltaTime * Input.GetAxis("Oculus_GearVR_LThumbstickX");

        this.transform.position +=
            (new Vector3(head.right.x, 0f, head.right.z)).normalized *
            movementSpeed * Time.deltaTime * Input.GetAxis("LeftJoystickX");
    }

    private void MoveBackwardOrForward()
    {
        //Superman
        //this.transform.position += head.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Oculus_GearVR_LThumbstickY") ;
        //this.transform.position += head.forward * movementSpeed * Time.deltaTime * Input.GetAxis("LeftJoystickY");

        //Flat Moving
        this.transform.position +=
            (new Vector3(head.forward.x, 0f, head.forward.z)).normalized
            * movementSpeed * Time.deltaTime * Input.GetAxis("LeftJoystickY");


    }
}