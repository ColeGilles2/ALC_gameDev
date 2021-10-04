using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour {

    public float speed = 15;



    // Update is called once per frame
    void Update() {
        // move forward
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
