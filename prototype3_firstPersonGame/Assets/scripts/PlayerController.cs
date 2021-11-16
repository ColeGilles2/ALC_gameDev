using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("Stats")]
    public int curHP;
    public int maxHP;

    [Header("Movement")]
    public float moveSpeed; //how fast move
    public float jumpForce; // how high can jumpp

    [Header("Camera")]
    public float lookSensetivity; //sensetivity
    public float maxLookX; //how low you can look
    public float minLookX; // how high you can look
    private float rotX; // current x position

    [Header("Components")]
    private Camera cam; // declares a camera
    private Rigidbody rb; // finds rigidbody
    private Weapon weapon; //finds weapon
    
    void Awake() {
        //get components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();

        Cursor.lockState = CursorLockMode.Locked;
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
        //get buttons
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //movement
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
        //mouse axis
        float y = Input.GetAxis("Mouse X") * lookSensetivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensetivity; 

        //clamp the verticle rotation of camera
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        //applying the rotation to camera
        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    public void TakeDamage(int damage) {
        curHP -= damage;

        if(curHP <= 0) {
            Die();
        }
    } 

    void Die() {
        print("You're trash kid");
    }

    public void GiveHealth(int amountToGive) {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
    }

    public void GiveAmmo(int amountToGive) {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
    }

}
