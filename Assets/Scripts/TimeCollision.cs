using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCollision : MonoBehaviour
{

    private AudioSource timeAudio;
    public AudioClip timeSound;
    

    // Start is called before the first frame update
    void Start()
    {
        timeAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player")){
            Destroy(this.gameObject, timeSound.length);
        }

        timeAudio.PlayOneShot(timeSound, 0.8f);
    }
}
