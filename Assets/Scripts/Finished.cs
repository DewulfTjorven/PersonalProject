using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Finished : MonoBehaviour
{

    public GameObject player;
    public TextMeshProUGUI finishedText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish"){
            player.GetComponent<PlayerController>().isGrounded = false;
            player.GetComponent<PlayerController>().speed = 0;
            player.GetComponent<TimerCountdown>().timerIsRunning = false;
            Debug.Log("Finished!");
            finishedText.text = "Finished!";
        }
    }

}
