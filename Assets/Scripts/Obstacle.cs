using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public GameObject particleEffect;

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
            Instantiate(particleEffect, transform.position, transform.rotation);

            Destroy (gameObject);
		}
	}
}
