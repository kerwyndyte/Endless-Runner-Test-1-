using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<LifeCount>().lives = 0; //Sets Lives to 0 (which triggers the pause)
            other.GetComponent<PlayerMotor>().SetSpeed(0); // Sets player speed to 0
            GetComponent<ReaperMotor>().SetSpeed(0); // Sets reaper speed to 0

            //Destroy(gameObject);
        }

    }
}
