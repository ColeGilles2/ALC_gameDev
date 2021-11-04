using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    //data types
    public ObjectPool bulletPool; //bullet game object
    public Transform muzzle; // jusszle transform
    public int curAmmo; //current ammo
    public int maxAmmo; // how much ammo you can have 
    public bool infiniteAmmo; //infite ammo
    public float bulletSpeed; //bullet seed
    public float shootRate; //shoot rate 
    public float lastShootTime; //time since lats shot
    public bool isPlayer; //check if player 
    
    void Awake() {
        //are we still attached to player?
        if (GetComponent<PlayerController>()) {
            isPlayer = true;
        }
    }

    //can we shoot
    public bool CanShoot() {
        if (Time.time - lastShootTime >= shootRate) {
            if (curAmmo > 0 || infiniteAmmo == true) {
                return true;
            }
        }

        return false;
    }

    public void Shoot() {
        //adjust shoot time and reduce ammo by one
        lastShootTime = Time.time;
        curAmmo--;

        // create bullet
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;

        //set volicty of bulletprojectile
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }

}

