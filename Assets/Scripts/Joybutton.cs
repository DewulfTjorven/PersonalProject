using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Joybutton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    protected bool Pressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData){
        Pressed = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnPointerUp(PointerEventData eventData){
        Pressed = false;
    }
}
