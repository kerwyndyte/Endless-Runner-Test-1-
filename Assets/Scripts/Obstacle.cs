using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public GameObject particleEffect;

   	private void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
            Instantiate(particleEffect, transform.position, transform.rotation);
            GameObject.Find("Player_Runner").GetComponent<LifeCount>().lives--;
            GameObject.Find("Player_Runner").GetComponent<LifeCount>().LivesDown();
            Destroy (gameObject);
                

		}
	}
}
