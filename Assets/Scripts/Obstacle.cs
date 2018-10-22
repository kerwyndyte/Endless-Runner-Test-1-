using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    //private GameObject player = GameObject.FindGameObjectWithTag("Player");

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {


	}

	private void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
            other.GetComponent<LifeCount>().lives--;
			Destroy (gameObject);
		}
	}
}
