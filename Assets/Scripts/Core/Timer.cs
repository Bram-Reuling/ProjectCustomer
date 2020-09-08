using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ProjectCustomer.Core
{
    public class Timer : MonoBehaviour
    {

        // Set the timeRemaining to 300 seconds || 5 minutes
        [Tooltip("Time in seconds.")] public float timeRemaining = 300f;
        public float addSecondsPerFireExtinguished = 20;
        public TextMeshProUGUI timerText;
        private bool isTimerRunning;

        private void Start()
        {
            isTimerRunning = true;
            EventBroker.EventOnFireExtinguished += AddSeconds;
        }

        private void Update()
        {
            if (!isTimerRunning) return;
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                isTimerRunning = false;
                // TODO: Call this event ONE time.
                // Probably does that already bc this is getting destroyed after the event happened...
                EventBroker.CallEventOnTimerRunOut();
            }
            DisplayTimeLeft(timeRemaining);
        }

        private void DisplayTimeLeft(float time)
        {
            time += 1;
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);

            timerText.text = $"Time Remaining: {minutes:00}:{seconds:00}";
        }

        private void AddSeconds()
        {
            timeRemaining += addSecondsPerFireExtinguished;
        }
    }
}
