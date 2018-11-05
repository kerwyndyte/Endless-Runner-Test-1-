using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;
    Animator player_animator;

    public float speed = 5.0f;
    public float newSpeed;
    private float jump = 100.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 120.0f;
    private float animationDuration = 2.0f;

    private bool myFuncWasCalled;



    // Use this for initialization
    void Start ()
    {

        controller = GetComponent<CharacterController>();
        player_animator = GetComponent<Animator>();
        		
	}

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero; //Reset Value
        if(Input.GetMouseButtonDown(0))
        {
            bool isJumpingPressed = (Input.mousePosition.y >= Screen.height / 2);
            if(isJumpingPressed)
             player_animator.SetTrigger("IsJumping");
            //player_animator.SetBool("IsJumping",);
        }
        
        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
            
            
        }
        else
        {
            return;            
        }

        

        // X - Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
                moveVector.x = -5;
            else
                moveVector.x = 5;
        }

        // Y - Up and Down
        moveVector.y = verticalVelocity; //replace with jump animation

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

    // Power Ups
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Speedup")
        {
            speed = 5.5f;
            StartCoroutine(SpeedTimer(5));
        }

        if (other.tag == "Obstacle")
        {
            if(myFuncWasCalled)
            {
                newSpeed--;
                newSpeed--;
                StartCoroutine(ObstacleTimer(3));
            }
            else
            {
                speed--;
                speed--;
                StartCoroutine(ObstacleTimer(3));
            }
            
        }
    }

    // Reset Speed
    IEnumerator SpeedTimer(float time)
    {
        yield return new WaitForSeconds(5);
        speed = 5.0f;
    }

    IEnumerator ObstacleTimer(float time)
    {
        if(myFuncWasCalled)
        {
            yield return new WaitForSeconds(3);
            newSpeed++;
            newSpeed++;
        }
        else
        {
            yield return new WaitForSeconds(3);
            speed++;
            speed++;
        }
        
        
    }

    public void SetSpeed(float modifier)
    {
        myFuncWasCalled = true;
        newSpeed = 5.0f + modifier;
    }
}
