using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeCount : MonoBehaviour {

    
    public int lives = 3;
    public GameObject GameOver;
    public static bool GameisPaused = false;


    // Use this for initialization
    void Start () {
        GameOver.gameObject.SetActive(true);
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

        

    }

	private void OnGUI()
	{
		GUI.Label(new Rect(10, 30, 100, 50), "Candy: " + lives); 
	}
}
