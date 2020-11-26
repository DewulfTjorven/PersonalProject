using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 100.0f;
    private float turnSpeed = 55.0f;
    private float horizontalInput;
    private float forwardInput;

    public GameObject ground;
    private bool isGrounded;

    public Rigidbody rb;
    public Vector2 movement;

    // RaycastHit hit;
    // private float distance = 5.0f;
    // private Vector3 targetLocation;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        forwardInput = Mathf.Lerp (forwardInput,Input.GetAxis("Vertical"),Time.deltaTime*0.3f);
        horizontalInput = Input.GetAxis("Horizontal");

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
        // Auto vertragen achter collision, misschien nog proberen met extra tijd?
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground"){
            isGrounded = true;
            Debug.Log(isGrounded);
        }
        else{
            isGrounded = false;
        }
    }

    
    void moveCharacter(Vector2 direction)
    {    
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}





        