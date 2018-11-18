using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float time = 0;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 20;
    
    public Text timeText;

	// Use this for initialization
	void Start () {

        timeText.text = "0";
		
	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime; //Score increases every second
        if (time >= scoreToNextLevel)
        {
            LevelUp();
        }

        timeText.text = ((int)time).ToString();
		
	}

    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
        { return; }
        scoreToNextLevel *= 2;
        difficultyLevel++;
        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);
        GameObject.Find("reaper_ting").GetComponent<ReaperMotor>().SetSpeed(difficultyLevel);
        //Level 1 Speed = 5
        //Level 2 Speed = 6
        //Level 3 Speed = 7 etc
    }
}
