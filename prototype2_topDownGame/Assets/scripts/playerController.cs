using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    //move and turn speed
    public float speed = 5.0f;
    public float turnSpeed = 150.0f;
    //inpu vars
    private float hInput;
    private float vInput;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        //get key press
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        //move
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
        transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime * hInput);
    }
}
