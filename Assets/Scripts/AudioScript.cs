using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour {

    public AudioClip MainMenuMusic;
    public AudioSource MusicSource;

    // Use this for initialization
    void Start()
    {

        MusicSource.clip = MainMenuMusic;

    }

    // Update is called once per frame
    void Update()
    {

        MusicSource.Play();

    }
}
