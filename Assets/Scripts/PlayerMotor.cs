using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;
    public float speed = 3.0f;
    public float newSpeed;
    private float verticalVelocity = -0.5f;
    //private float gravity = 120.0f;
    private float animationDuration = 2.0f;
    private bool myFuncWasCalled;
    


    // Use this for initialization
    void Start ()
    {

        controller = GetComponent<CharacterController>();
        
        		
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

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;           
        }
        else
        {
            return;            
        }

        // Z - Forward and Backwards
        if (myFuncWasCalled)
        {
            moveVector.z = newSpeed;
        }
        else
        {
            moveVector.z = speed;
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
                     
        controller.Move(moveVector * Time.deltaTime);

		
	}
     

    
    // Obstacles
    public void OnTriggerEnter(Collider other)
    {
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

        /*if (other.tag == "Enemy")
        {
            
        }*/
    }

    // Reset Speed
    IEnumerator SpeedTimer(float time)
    {
        yield return new WaitForSeconds(5);
        speed = 3.5f;
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
        newSpeed = 3.0f + modifier;
    }
}
