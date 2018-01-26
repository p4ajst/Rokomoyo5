﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    GameObject cameraObj;
    bool rightFlag = false;
    bool leftFlag = false;
    bool centerFlag = false;

	// Use this for initialization
	void Start () {
        //cameraObj = GameObject.Find("Camera/Main Camera");
        cameraObj = GameObject.Find("Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if(rightFlag)
            cameraObj.transform.Rotate(new Vector3(0, -0.5f, 0));
        if (leftFlag)
            cameraObj.transform.Rotate(new Vector3(0, 0.5f, 0));

        if(centerFlag)
        {
            if (cameraObj.transform.rotation.y > 0)
            {
                cameraObj.transform.Rotate(new Vector3(0, -1f, 0));
                if (cameraObj.transform.rotation.y <= 0)
                {
                    cameraObj.transform.Rotate(new Vector3(0, 0, 0));
                    centerFlag = false;
                }
            }
            if (cameraObj.transform.rotation.y < 0)
            {
                cameraObj.transform.Rotate(new Vector3(0, 1f, 0));
                if (cameraObj.transform.rotation.y >= 0)
                {
                    cameraObj.transform.Rotate(new Vector3(0, 0, 0));
                    centerFlag = false;
                }
            }
        }
    }

    public void RightClick()
    {
        rightFlag = true;
    }

    public void LeftClick()
    {
        leftFlag = true;
    }

    public void CenterClick()
    {
        Debug.Log(cameraObj.transform.rotation.y);
        centerFlag = true;
    }

    public void NoneClick()
    {
        rightFlag = leftFlag = false;
    }
}
