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

    //edge borders
    public float edgeX = 8.86f;
    public float edgeY = -4.47f;

    //bullet and position to shoot from
    public GameObject bullet;

    public GameObject firePoint;
    

    // Update is called once per frame
    void Update() {
        //get key press
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        //movement
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
        transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime * hInput);

        //x edge borders
        if (transform.position.x > edgeX) {
            transform.position = new Vector3(edgeX, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -edgeX) {
            transform.position = new Vector3(-edgeX, transform.position.y, transform.position.z);
        }

        //y borders
        if (transform.position.y < edgeY) {
            transform.position = new Vector3(transform.position.x, edgeY, transform.position.z);
        }
        if (transform.position.y > -edgeY) {
            transform.position = new Vector3(transform.position.x, -edgeY, transform.position.z);
        }

        //shoot controlls
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        }

    }
}
