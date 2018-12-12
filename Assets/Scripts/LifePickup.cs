using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LifePickup : MonoBehaviour {

    public GameObject particleEffect;
    public AudioClip PowerUp;
    public AudioSource MusicSource;

    // Use this for initialization
    void Start () {
        MusicSource.clip = PowerUp;
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
            MusicSource.Play();
            

            GameObject.Find("Player_Runner").GetComponent<Score>().candy++;
            //isPlaying = false;
            if (MusicSource.isPlaying == false)
                Destroy (gameObject);
            
		}

	}
}
