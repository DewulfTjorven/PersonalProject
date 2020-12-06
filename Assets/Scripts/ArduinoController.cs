using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoController : MonoBehaviour
{

    public GameObject player;
    public float potentioData;
    public float speed = 60.0f;
    public float turnSpeed;
    private bool dataRead;
    public float vertical;

    //SerialPort port = new SerialPort("COM3", 9600);
    SerialPort port = new SerialPort("/dev/cu.usbmodem14101", 9600);

    // Start is called before the first frame update
    void Start()
    {
        // kijkt of port open staat
        port.Open();
        port.ReadTimeout = 100;
    }

    // Update is called once per frame
    void Update()
    {
        // wanner de speler kan rijden dan kan hij ook via de potentiometer aan het stuur draaien
        if(player.GetComponent<PlayerController>().isGrounded == true){
            transform.Rotate((transform.up * (potentioData / 10)) * turnSpeed * Time.deltaTime);
            potentioData = float.Parse(port.ReadLine());
            Debug.Log(potentioData);
        }
    }

}



