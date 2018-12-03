using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "player")
        {
            Debug.Log("Complete");
            Destroy(gameObject);
        }
	}
}
