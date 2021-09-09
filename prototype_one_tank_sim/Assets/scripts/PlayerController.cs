using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 15.0f;
    public float turnSpeed = 30.0f;

    // left right
    public float hInput;
    // forward and back
    public float vInput;

    // projectile

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // button press values for horizontal and vertical inputs
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        //makes the tank go left and right
        transform.Rotate(Vector3.up, turnSpeed * hInput * Time.deltaTime);
        //makes the tank go forward and backwards
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput);

    }
}
