using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockAnimate : MonoBehaviour
{

    public float rotationsPerMinute  = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,6.0f*rotationsPerMinute*Time.deltaTime,0f);    }
    }
