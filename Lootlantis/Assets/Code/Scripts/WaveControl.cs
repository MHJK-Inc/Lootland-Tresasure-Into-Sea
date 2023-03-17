using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControl : MonoBehaviour
{
    public float TimeLeft;
    public float EnemiesLeft;
    public bool TimerOn;
    public TMPro.TextMeshProUGUI TimerTxt;
    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
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
            if(TimerOn)
            {
                if (TimeLeft > 0)
                {
                    TimeLeft -= Time.deltaTime;
                    updateTimer(TimeLeft);
                } else {
                    
                }
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("Survive For: {0:00} : {1:00}", minutes, seconds);
    }
}
