using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float time = 0;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 20;
    public int candy = 0;
    //public int lives;
    public Text CandyText;
    public Text timeText;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    // Use this for initialization
    void Start () {

        

        timeText.text = "0";
        CandyText.text = "0";

    }
	
	// Update is called once per frame
	void Update () {

        
        if (candy > 100)
        {
            LivesUp();            
            candy = 0;
        }

        time += Time.deltaTime; //Score increases every second
        if (time >= scoreToNextLevel)
        {
            LevelUp();
        }

        timeText.text = ((int)time).ToString();
        CandyText.text = candy.ToString();
        
    }

    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
        { return; }
        scoreToNextLevel *= 3;
        difficultyLevel++;
        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);
        GameObject.Find("reaper_ting").GetComponent<ReaperMotor>().SetSpeed(difficultyLevel);
        //Level 1 Speed = 2
        //Level 2 Speed = 3
        //Level 3 Speed = 4 etc
    }

    public void LivesUp()
    {
        
        GetComponent<LifeCount>().lives++;
        
        if (GetComponent<LifeCount>().lives == 3)// && Heart3.gameObject.activeSelf == false)           
        { 
            Heart3.gameObject.SetActive(true);          
        }
        

        if (GetComponent<LifeCount>().lives == 2) //&& Heart2.gameObject.activeSelf == false)
        {
            
            
            Heart2.gameObject.SetActive(true);
            


        }
        
        if (GetComponent<LifeCount>().lives == 1)// && Heart1.gameObject.activeSelf == false)
        {


            Heart1.gameObject.SetActive(true);          


        }
        
        return;




    }
}
