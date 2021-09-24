using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour  {
 
    private Vector3 mousePosition;
    private float moveSpeed = 1.0f;
    private float timer = 3.0f;
    // can dash
    private bool dashCheck = true;
 
    void dash() {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed / 20);
    }

    // Use this for initialization
    void Start () {

    }
   
    // Update is called once per frame
    void Update () {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed * Time.deltaTime);

        // ADD TIMER FOR DASH
        if (Input.GetMouseButton(0)) {
            if (dashCheck == true) {
                dash();
            }
        }

        //TIMER
        Debug.Log(timer);
    }
}