using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public GameObject player;
    private float timeRemaining = 3;//120//;
    public bool timerIsRunning = false;
    public TextMeshProUGUI countdownText;

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
                player.GetComponent<PlayerController>().isGrounded = false;
                player.GetComponent<TimerCountdown>().timerIsRunning = false;

            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                Destroy(countdownText);
                player.GetComponent<PlayerController>().isGrounded = true;
                player.GetComponent<TimerCountdown>().timerIsRunning = true;

            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        countdownText.text = string.Format("{1:00}", minutes, seconds);
    }
}
