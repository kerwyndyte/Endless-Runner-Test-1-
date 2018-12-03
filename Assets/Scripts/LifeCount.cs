using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeCount : MonoBehaviour {

    
    public int lives = 3;
    public int candy = 0;
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
        if (candy == 100)
        {
            lives++;
        }

        if (lives <= 0)
        {
            GameOver.gameObject.SetActive(true);
            Time.timeScale = 0f;
            GameisPaused = true;
        }

        

        

    }

	private void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 50), "Lives : " + lives);
        GUI.Label(new Rect(10, 20, 100, 50), "Candy : " + candy);
    }
}
