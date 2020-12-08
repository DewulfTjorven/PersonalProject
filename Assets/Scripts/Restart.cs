using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update ()
    {

        if(Input.GetKeyDown(KeyCode.R) || Input.GetButton("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
   }
}
