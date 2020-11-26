using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 100.0f;
    private float turnSpeed = 55.0f;
    private float horizontalInput;
    private float forwardInput;

    public Rigidbody rb;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        forwardInput = Mathf.Lerp (forwardInput,Input.GetAxis("Vertical"),Time.deltaTime*0.3f);
        horizontalInput = Input.GetAxis("Horizontal");

        void OnTriggerEnter(Collider other){
            speed /= 8.0f;
            Debug.Log("Slowed");
        }

        void OnTriggerExit(Collider other){
            speed *= 8.0f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        moveCharacter(movement);

        // Auto vertragen achter collision, misschien nog proberen met extra tijd?
        
    }

    void moveCharacter(Vector2 direction)
    {   
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);


    }

    
}





        