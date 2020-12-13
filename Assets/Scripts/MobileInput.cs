using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.MobileJoystick;
using UnityEngine.SceneManagement;



public class MobileInput : MonoBehaviour
{

    private Rigidbody rb;
    public GameObject player;
    private float speed = 60;
    private float turnSpeed = 20;
    public Joystick Rotate;
    public Button Drive;
    public Button Brake;
    public Button Restart;
    public TouchField TouchField;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // wanneer de speler kan rijden dan kan hij ook via de potentiometer aan het stuur draaien
        if(player.GetComponent<PlayerController>().isGrounded == true){
            transform.Rotate(transform.up , TouchField.TouchDist.x);

            if(Drive.Pressed){
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }

            if(Brake.Pressed){
                rb.MovePosition(transform.position + transform.forward * -1 * Time.deltaTime * speed);
            }
        }

        

        if(Restart.Pressed){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
