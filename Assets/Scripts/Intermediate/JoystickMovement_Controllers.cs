using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement_Controllers : MonoBehaviour {

    public Transform head;

    public float rotationSpeed = 180f;
    public float movementSpeed = 3f;

    public 
    
	void Update () {
        //RotateLeftOrRight();
        //MoveBody();
	}

    private void FixedUpdate()
    {
        RotateLeftOrRight();
        MoveBody();
    }

    private void RotateLeftOrRight()
    {

        this.transform.RotateAround(head.position, Vector3.up, Input.GetAxis("RightXJoystick") * rotationSpeed * Time.fixedDeltaTime);

    }

    private void MoveBody()
    {


        Vector3 headForward =  (new Vector3(head.forward.x, 0f, head.forward.z)).normalized;
        Vector3 headRight = (new Vector3(head.right.x, 0f, head.right.z)).normalized;



        this.transform.position += 
            headRight * Input.GetAxis("LeftXJoystick") * movementSpeed * Time.fixedDeltaTime +
            headForward* Input.GetAxis("LeftYJoystick") * -movementSpeed * Time.fixedDeltaTime;

    }

}
