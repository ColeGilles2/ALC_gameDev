using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // movement 
    public float moveSpeed; //how fast move
    public float jumpForce; // how high can jumpp

    //camera
    public float lookSensetivity; //sensetivity
    public float maxLookX; //how low you can look
    public float minLookX; // how high you can look
    private float rotX; // current x position

    //componemts
    private Camera cam; // declares a camera
    private Rigidbody rb; // finds rigidbody
    private Weapon weapon;
    
    void Awake() {
        //get components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

        weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update() {
        Move();
        CamLook();
        //jump button
        if (Input.GetButtonDown("Jump"))
            Jump();
        // fire button
        if (Input.GetButton("Fire1")) {
            if (weapon.CanShoot()) {
                weapon.Shoot();
            }
        }
    }

    void Move() {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 dir = transform.right * x + transform.forward * z;
        dir.y = rb.velocity.y;
        rb.velocity = dir;
    } 

    void Jump() {
        //cast ray to ground
        Ray ray = new Ray(transform.position, Vector3.down);
        //check ray lenght to jump 
        if (Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void CamLook() {
        float y = Input.GetAxis("Mouse X") * lookSensetivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensetivity; 

        //clamp the verticle rotation of camera
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        //applying the rotation to camera
        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

}
