using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class Adv_VRTeleport : MonoBehaviour {

    public Material lineMaterial;
    private LineRenderer line;
    public float maxTeleportDistance = 15f;
    public float playerHeight = 1.75f;


    public KeyCode activationButton = KeyCode.JoystickButton2;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(activationButton))
        {
            InitializeLine();
        }
        else if(Input.GetKey(activationButton))
        {
            UpdateLine();
        }
        else if(Input.GetKeyUp(activationButton))
        {
            bool canTeleport = CanTeleportToPoint();
            if (canTeleport)
            {
                TeleportToPoint();
            }
            DestroyLine();
        }


    }

    private void InitializeLine()
    {
        line = this.gameObject.AddComponent<LineRenderer>();
        line.material = lineMaterial;
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;

        UpdateLine();

    }

    private Vector3 GetTeleportPoint()
    {
        RaycastHit hitInfo = new RaycastHit();

        if(Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, maxTeleportDistance))
        {
            return hitInfo.point;
        }else
        {
            return this.transform.position + this.transform.forward * maxTeleportDistance;
        }
    }

    private void UpdateLine()
    {
        //Array
        Vector3[] linePoints = new Vector3[2];

        //{ Vector3 (0,1,0),  Vector2(1,1,1) }
        //First Point
        linePoints[0] = this.transform.position;
        //secondpoint on the list
        linePoints[1] = GetTeleportPoint();

        line.SetPositions(linePoints);

        if (CanTeleportToPoint())
        {
            line.material.SetColor("_TintColor", Color.green);
        }
        else
        {
            line.material.SetColor("_TintColor", Color.red);
        }
    }

    private bool CanTeleportToPoint()
    {
        RaycastHit hitInfo = new RaycastHit();

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, maxTeleportDistance))
        {
            if(hitInfo.transform.tag == "Teleportable")
            {
                return true;
            }
        }


        return false;
    }

    private void TeleportToPoint()
    {
        Vector3 teleportPoint = GetTeleportPoint();

        Vector3 headLocalPosition = Camera.main.transform.localPosition;

        this.transform.root.position = new Vector3(teleportPoint.x - headLocalPosition.x, 
            playerHeight + teleportPoint.y - headLocalPosition.y, 
            teleportPoint.z - headLocalPosition.z);
    }


    private void DestroyLine()
    {
        if(line != null)
        {
            Destroy(line);
        }
    }
}
