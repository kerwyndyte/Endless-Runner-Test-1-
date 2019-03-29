using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Audio;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    
    [SerializeField]
    private Vector3 moveVector;
    public float speed = 2.0f;
    public float newSpeed;
    private float verticalVelocity = -0.5f;
    
    [SerializeField]
    private float animationDuration = 2.0f;
    private bool myFuncWasCalled;
    public AudioClip PowerUp;
    public AudioSource MusicSource;



    // Use this for initialization
    void Start ()
    {

        controller = GetComponent<CharacterController>();
        MusicSource.clip = PowerUp;


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

        

        moveVector.x = CrossPlatformInputManager.GetAxis("Horizontal") * 100;
        if (CrossPlatformInputManager.GetButtonDown("LeftButton"))
        {
            //moveVector.x = -5 * speed;
        }
        else if (CrossPlatformInputManager.GetButtonDown("RightButton"))
        {
            //moveVector.x = 5 * speed;
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

                       
        moveVector.y = -0.5f; //replace with jump animation
        

      

        controller.Move(moveVector * Time.deltaTime);

        		
	}

    
        
    // Obstacles
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if(myFuncWasCalled)
            {
                newSpeed = newSpeed - 2;
                StartCoroutine(ObstacleTimer(3));
            }
            else
            {
                speed = speed - 2;
                StartCoroutine(ObstacleTimer(3));
            }
            
        }

        if (other.CompareTag("Pickup"))
        {
            MusicSource.Play();
        }
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
            newSpeed = newSpeed + 2;
            
        }
        else
        {
            yield return new WaitForSeconds(3);
            speed = speed + 2;
    
        }
        
        
    }

    public void SetSpeed(float modifier)
    {
        myFuncWasCalled = true;
        newSpeed = speed + modifier;
    }   
}
