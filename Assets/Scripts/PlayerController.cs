using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float speed = 60.0f;
    private float turnSpeed = 55.0f;
    private float horizontalInput;
    private float forwardInput;

    public GameObject ground;
    private bool isGrounded;

    public Rigidbody rb;
    public Vector2 movement;

    private AudioSource playerAudio;
    public AudioClip crashSound;

    public TextMeshProUGUI speedText;

    // RaycastHit hit;
    // private float distance = 5.0f;
    // private Vector3 targetLocation;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        forwardInput = Mathf.Lerp (forwardInput,Input.GetAxis("Vertical"),Time.deltaTime*0.3f);
        horizontalInput = Input.GetAxis("Horizontal");

        speedText.text = "speed " + speed.ToString();
        

        
        // void OnTriggerEnter(Collider other){
        //     speed /= 8.0f;
        // }

        // void OnTriggerExit(Collider other){
        //     speed *= 8.0f;
        // }
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(isGrounded){
            moveCharacter(movement);
        }
    }
    
    void moveCharacter(Vector2 direction)
    {    
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacle"){
            isGrounded = true;
        }
        else{
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Boost")){
            speed += 10.0f;
            Destroy(other.gameObject);
        }
    }


}





        