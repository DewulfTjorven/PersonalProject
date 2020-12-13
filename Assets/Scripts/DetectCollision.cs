using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    private AudioSource crashAudio;
    public AudioClip crashSound;

    // Start is called before the first frame update
    void Start()
    {
        crashAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Player")){
            crashAudio.PlayOneShot(crashSound, 0.2f);
        }
    }
}
