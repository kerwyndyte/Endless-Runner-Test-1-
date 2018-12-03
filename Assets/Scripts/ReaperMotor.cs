using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperMotor : MonoBehaviour {
    private CharacterController controller;
    private Vector3 moveVector;

    public float speed = 3.0f;
    public float newSpeed;
    private float animationDuration = 2.0f;

    private bool myFuncWasCalled;

    // Use this for initialization
    void Start () {
        
        controller = GetComponent<CharacterController>();
       
    }
	
	// Update is called once per frame
	void Update () {

        if (Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero; //Reset Value
        // Z - Forward and Backwards

        if (myFuncWasCalled)
        {
            moveVector.z = newSpeed;
        }
        else
        {
            moveVector.z = speed;
        }

        controller.Move(moveVector * Time.deltaTime);
        
    }

    public void SetSpeed(float modifier)
    {
        myFuncWasCalled = true;
        newSpeed = 3.0f + modifier;
    }
}
