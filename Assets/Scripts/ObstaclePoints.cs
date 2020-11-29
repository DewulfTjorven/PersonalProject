using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObstaclePoints : MonoBehaviour
{
    private float points = 0;
    public TextMeshProUGUI pointText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = "Your points " + points.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Obstacle")){
            points += 10;
        }
    }
}
