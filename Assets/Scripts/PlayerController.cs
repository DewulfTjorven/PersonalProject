﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 60.0f;
    public float turnSpeed = 50.0f;
    public float vertical;
    public float horizontal;

    public GameObject player;
    public GameObject ground;
    public bool isGrounded;
    private bool onLooping = false;

    private Rigidbody rb;

    private AudioSource playerAudio;
    public AudioClip crashSound;

    public TextMeshProUGUI speedText;
    public TextMeshProUGUI crashText;

    private float triggerrayDownLength = 0.5f;

    public Joystick joystick;
    public Joystick joystickRotate;

    public float mobileVertical;
    public float mobileHorizontal;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(onLooping == false){
            RayCastDown();
        }

        vertical = Mathf.Lerp (vertical,Input.GetAxis("Vertical"),Time.deltaTime*0.25f);
        horizontal = Input.GetAxis("Horizontal");

        mobileVertical = Mathf.Lerp (mobileVertical,joystick.Vertical,Time.deltaTime*0.25f);
        mobileHorizontal = joystickRotate.Horizontal;

        if(isGrounded == true){
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed * vertical);
            // Mobile input needs new method to acces the joystick axis for acceleration
            //rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed * mobileVertical);
            
            transform.Rotate((transform.up * horizontal) * turnSpeed * Time.deltaTime);
            // mobile roate to acces second joystick
            //transform.Rotate((transform.up * mobileHorizontal) * (turnSpeed * 1.05f) * Time.deltaTime);
        }

        // if(isGrounded == false){
        //     Debug.Log("Crashed!");
        // }
        speedText.text = "Max speed " + speed.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Boost")){
            speed += 10.0f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Loop"){
                isGrounded = true;
                onLooping = true;
                Debug.Log("Looping!");
        } 
        else{
            onLooping = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        onLooping = false;
    }

    void RayCastDown()
     {
         RaycastHit hit;  
         //Debug.DrawRay(transform.position, Vector3.down * triggerrayDownLength, Color.red, 2, true);
         if (Physics.Raycast(transform.position, Vector3.down, out hit, triggerrayDownLength))
             {
                if (hit.collider.gameObject.tag == "Ground" || hit.collider.gameObject.tag == "Obstacle" || hit.collider.gameObject.tag == "Looping" || hit.collider.gameObject.tag == "Finish") 
                {
                    isGrounded = true;
                    //Debug.Log("Hit");
                }
                 
                else    
                {
                    isGrounded = false;
                    crashText.text = "You crashed!";
                    player.GetComponent<TimerCountdown>().timerIsRunning = false;
                    //Debug.Log("Nothing Hit");
                    // speed = 0;
                    // turnSpeed = 0;
                }
             }
     }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish"){
            Debug.Log("Finished!");
            //isGrounded = false;
            speed = 0;
            turnSpeed = 0;
        }
    }
}