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
            GameOver.gameObject.SetActive(true);
            Time.timeScale = 0f;
            GameisPaused = true;

            
        }


        if(GetComponent<Score>().candy == 100)
        {
            LivesUp();
        }

        LivesDown();
        
        
        

    }

    private void LivesUp()
    {
        if (lives == 1)
        {
            if (Heart1.gameObject == (true) && Heart2.gameObject == (false) && Heart3.gameObject == (false))
            {
                Heart2.gameObject.SetActive(true);
            }
        }
        else if (lives == 2)
        {
            if (Heart1.gameObject == (true) && Heart2.gameObject == (true) && Heart3.gameObject == (false))
            {
                Heart3.gameObject.SetActive(true);
            }
        }
        
    }

    private void LivesDown()
    {
        if (lives == 2)
        {
            if (Heart1.gameObject == (true) && Heart2.gameObject == (true) && Heart3.gameObject == (true))
            {
                Heart3.gameObject.SetActive(false);
            }
        }
        else if (lives == 1)
        {
            if (Heart1.gameObject == (true) && Heart2.gameObject == (true) && Heart3.gameObject == (false))
            {
                Heart2.gameObject.SetActive(false);
            }
        }
        else if (lives < 1)
        {
            Heart1.gameObject.SetActive(false);
        }
    }
       

	
}
