using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControl : MonoBehaviour
{
    public float TimeLeft;
    public float EnemiesLeft;
    public bool TimerOn;
    public TMPro.TextMeshProUGUI TimerTxt;
    public TMPro.TextMeshProUGUI KillTxt;
    public WaveClear waveClear;
    // Start is called before the first frame update

    


    void Start()
    {
        TimerOn = true;
        EnemiesLeft = 10;
        

        //different wave settings in a method
        //method to randomize active objectives
        //set wave timer (1 min?)
        //set enemies left (10?)
        //End round if either hit 0
        //Call Level Up
        //Call to next wave
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            Timer();
            UpdateKill();
        }
    }

    private void SetUp()
    {
        if (PlayerPrefs.GetInt("Wave") == 1)
        {
            TimeLeft = 60;
            EnemiesLeft = 10;
        } else if (PlayerPrefs.GetInt("Wave") == 2)
        {
            TimeLeft = 60;
            EnemiesLeft = 10;
        }else if (PlayerPrefs.GetInt("Wave") == 3)
        {
            TimeLeft = 60;
            EnemiesLeft = 10;
        }else if (PlayerPrefs.GetInt("Wave") == 4)
        {
            TimeLeft = 60;
            EnemiesLeft = 10;
        } else
        {
            TimeLeft = 60;
            EnemiesLeft = 10;
        }

        
    }



    void Timer()
    {
        if(TimerOn)
            {
                if (TimeLeft > 0)
                {
                    TimeLeft -= Time.deltaTime;
                    UpdateTimer(TimeLeft);
                } else {
                    waveClear.Clear();
                }
            }   
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("Survive For: {0:00} : {1:00}", minutes, seconds);
    }

    void UpdateKill()
    {
        KillTxt.text = string.Format("Enemies Remaining: " + EnemiesLeft);
    }
}
