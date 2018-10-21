using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5.0f;
    private float jump = 100.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 120.0f;
    private float animationDuration = 2.0f;



    // Use this for initialization
    void Start ()
    {

        controller = GetComponent<CharacterController>();
        		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero; //Reset Value 
        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
            
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jump  Time.deltaTime; //replace with jump animation
            }*/
        }
        else
        {
            verticalVelocity = -gravity * Time.deltaTime;
        }
        // X - Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        // Y - Up and Down
        //moveVector.y = verticalVelocity; //replace with jump animation

        // Z - Forward and Backwards
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);

		
	}

    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }
}
