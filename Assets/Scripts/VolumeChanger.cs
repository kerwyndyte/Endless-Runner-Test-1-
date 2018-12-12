using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour {

    public Slider Volume;
    public AudioSource MainMenuMusic;
    

	// Use this for initialization
	void Start ()
    {
        //MainMenuMusic.volume = Volume.value;
	}
	
	// Update is called once per frame
	void Update () {
        MainMenuMusic.volume = Volume.value;
    }
}
