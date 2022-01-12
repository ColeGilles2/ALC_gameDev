using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour  {

    public bool run;// = true;
 
    private Vector3 mousePosition;
    private float moveSpeed = 2.0f;
   // private float timer = 3.0f;
    // can dash
    private bool dashCheck = true;

    public string color;

    public GameObject[] colors;

 
    void dash() {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed / 20);
    }

    // Use this for initialization
    void Start () {
        run = true;

        color = "green";
    }
   
    // Update is called once per frame
    void Update () {

        if (color == "red") {
            for (int i = 0; i < colors.Length; i ++) {
                colors[i].SetActive(false);
            }
            colors[0].SetActive(true);
        } else if (color == "blue") {
            for (int i = 0; i < colors.Length; i ++) {
                colors[i].SetActive(false);
            }
            colors[1].SetActive(true);
        } else if (color == "green") {
            for (int i = 0; i < colors.Length; i ++) {
                colors[i].SetActive(false);
            }
            colors[2].SetActive(true);
        } else {
            Destroy(gameObject);
        }

            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed * Time.deltaTime);
     
        // ADD TIMER FOR DASH
        if (Input.GetMouseButton(0)) {
            if (dashCheck == true) {
                dash();
            }
        }
    }
}