using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

using UnityEngine.XR.WSA.Input;

public class Player : MonoBehaviour
{

    public GameObject ball;
    public GameObject playerCamera;

    public float ballDistance = 2f;
    public float ballThrowingForce = 5f;

    private bool holdingBall = true;

    // Use this for initialization
    void Start()
    {
        ball.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        DownKeyCheck();
        if (holdingBall)
        {
            ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;

            if (Input.GetKeyUp(KeyCode.JoystickButton5))
            {
                holdingBall = false;
                ball.GetComponent<Rigidbody>().useGravity = true;
                ball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * ballThrowingForce);
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                holdingBall = true;
            }
        }


    }

    void DownKeyCheck()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    //処理を書く
                    Debug.Log(code);
                    break;
                }
            }
        }
    }
}
