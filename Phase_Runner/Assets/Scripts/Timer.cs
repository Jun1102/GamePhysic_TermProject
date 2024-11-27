using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Assets.Scripts;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text Date;
    private int cur_day = 0;
    private float timeRemaining = 180f; 
    private bool timerRunning = true;

	private void Start()
	{
        timeRemaining = Change_Maze.Instance.GetMazeCol();
	}

	void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                //timerRunning = false;
                TimerEnded();
                timeRemaining = Change_Maze.Instance.GetMazeCol();
			}
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
       
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimerEnded()
    {
        cur_day++;
        Date.text = "Day " + cur_day;
    }
}
