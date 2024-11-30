using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Assets.Scripts;
using System.Data;

namespace Assets.Scripts
{

    public class Timer : MonoBehaviour
    {
        private static Timer instance;
        public static Timer Instance { get { return instance; } }
        public TMP_Text timerText;
        public TMP_Text Date;
        public int cur_day = 0;
        public GameObject GameOver;
        private float timeRemaining;
        private bool timerRunning = true;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            timeRemaining = Change_Maze.Instance.GetMazeCol();
        }

        void Update()
        {
            if (cur_day == 7)
            {
                GameOver.transform.GetChild(1).gameObject.SetActive(true);
            }
            if (timerRunning)
            {
                if (timeRemaining > 0 && cur_day < 7)
                {
                    timeRemaining -= Time.deltaTime;
                    UpdateTimerDisplay(timeRemaining);
                }
                else
                {
                    timeRemaining = 0;
                    //timerRunning = false;
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

        public void SetTime()
        {
			TimerEnded();
			timeRemaining = Change_Maze.Instance.GetMazeCol();
		}
    }
}
