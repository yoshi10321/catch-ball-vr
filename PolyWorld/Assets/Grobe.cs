using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grobe : MonoBehaviour {

    public GameObject ball;
    private bool holdingBall = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (holdingBall)
        {
            ball.transform.position = gameObject.transform.position + gameObject.transform.forward;

            if (Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                holdingBall = false;
            }
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        holdingBall = true;
    }
}
