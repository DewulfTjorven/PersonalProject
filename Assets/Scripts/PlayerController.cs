using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float speed = 90.0f;
    private float turnSpeed = 55.0f;
    private float vertical;
    private float horizontal;

    public GameObject ground;
    private bool isGrounded;
    private bool onLooping = false;

    private Rigidbody rb;

    private AudioSource playerAudio;
    public AudioClip crashSound;

    public TextMeshProUGUI speedText;

    private float triggerrayDownLength = 0.5f;

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

        vertical = Mathf.Lerp (vertical,Input.GetAxis("Vertical"),Time.deltaTime*0.3f);
        horizontal = Input.GetAxis("Horizontal");

        if(isGrounded == true){
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed * vertical);
            transform.Rotate((transform.up * horizontal) * turnSpeed * Time.fixedDeltaTime);
        }

        if(isGrounded == false){
            // code here
        }

        speedText.text = "speed " + speed.ToString();
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
         Debug.DrawRay(transform.position, Vector3.down * triggerrayDownLength, Color.red, 2, true); //Makes the RayCast visible to make sure it's the right length.  
         if (Physics.Raycast(transform.position, Vector3.down, out hit, triggerrayDownLength)) //Shoots out a RayCast, Length is set at "rayLength" Var, 
             {
                if (hit.collider.gameObject.tag == "Ground" || hit.collider.gameObject.tag == "Obstacle" || hit.collider.gameObject.tag == "Looping") 
                {
                    isGrounded = true;
                    Debug.Log("Hit");
                }
                 
                else    
                {
                    isGrounded = false;
                    Debug.Log("Nothing Hit");
                    // speed = 0;
                    // turnSpeed = 0;
                }
             }
     }

         // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacle"){
    //         isGrounded = true;
    //         Debug.Log("Grounded!");
    //     }
    // }



}





        