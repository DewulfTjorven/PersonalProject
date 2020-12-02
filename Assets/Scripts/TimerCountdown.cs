using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    
    public GameObject player;
    private float timeRemaining = 120;//120//;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI FailedText;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.fixedDeltaTime;
                DisplayTime(timeRemaining);

                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.fixedDeltaTime;
                    DisplayTime(timeRemaining);
                }
            }
            else
            {
                player.GetComponent<PlayerController>().isGrounded = false;
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                timeText.text = "Time is up!";
                FailedText.text = "Too slow!" + "Press R to try again!";
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;

        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }

    // Voegt 5 seconden aan de timer toe wanneer de speler over een klokje gaat
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Clock")){
            timeRemaining += 10;
        }
    }
}
