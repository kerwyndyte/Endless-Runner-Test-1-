using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePickup : MonoBehaviour {

    public GameObject particleEffect;
    
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (90 * Time.deltaTime, 0, 0);
        
	}

	private void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
            Instantiate(particleEffect, transform.position, transform.rotation);

            GameObject.Find("Player_Runner").GetComponent<Score>().candy++;

            Destroy (gameObject);
		}

	}
}
