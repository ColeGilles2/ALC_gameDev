using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // movement 
    public float moveSpeed; //how fast move
    public float jumpForce; // how shigh can jumpp

    //camera
    public float lookSensetivity; //sensetivity
    public float maxLookX; //how high you can look
    public float minLookX; // how low you can look
    private float rotX; // current x position

    //componemts
    private Camera cam; // declares a camera
    private Rigidbody rb; // finds rigidbody
    
    void awake() {
        //get components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move() {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);
    } 

}
