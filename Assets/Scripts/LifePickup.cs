using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour {
    //private GameObject player = GameObject.FindGameObjectWithTag("Player");

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (0, 90 * Time.deltaTime, 0);
		
	}

	private void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
            if (other.GetComponent<LifeCount>().lives == 3)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                other.GetComponent<LifeCount>().lives++;
                Destroy(gameObject);
            }
		}

	}
}
