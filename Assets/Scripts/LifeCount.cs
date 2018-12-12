using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour {

    
    public int lives = 3;
    public GameObject GameOver;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;



    public static bool GameisPaused = false;


    // Use this for initialization
    void Start () {
        GameOver.gameObject.SetActive(false);
        Time.timeScale = 1f;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (lives <= 0)
        {
            PlayerPrefs.SetFloat("Highscore", GetComponent<Score>().time);
            GameOver.gameObject.SetActive(true);
            Time.timeScale = 0f;
            GameisPaused = true;
            

        }
    }

    

    public void LivesDown()
    {
        if (lives == 2) //&& GetComponent<Score>().candy <= 100)
        {
            Heart3.gameObject.SetActive(false);
            Debug.Log("LifeDown");
            return;
        }

        if (lives == 1) //&& Heart2.gameObject == (true) && GetComponent<Score>().candy <= 100)
        {
                      
           Heart2.gameObject.SetActive(false);
            Debug.Log("LifeDown");
            return;

        }

        else if (lives == 0)
        {
            Heart1.gameObject.SetActive(false);
            return;
            
        }


        return;
    }
       

	
}
