using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 85.0f;
    private float turnSpeed = 55.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void /*Fixed*/Update()
    {   

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Mathf.Lerp (forwardInput,Input.GetAxis ("Vertical"),Time.deltaTime*0.4f);

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        // Auto vertragen achter collision, misschien nog proberen met extra tijd?
        void OnTriggerEnter(Collider other){
            speed /= 7.0f;
        }

        void OnTriggerExit(Collider other){
            speed *= 7.0f;
        }
    }

    
}
