using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public GameObject child;
    private Vector3 offset = new Vector3(0, 6, -8);
    private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        follow();

    }

    private void follow(){
        transform.position = Vector3.Lerp(transform.position, child.transform.position, Time.deltaTime * speed);
        transform.LookAt(player.transform.position);
    }
}
