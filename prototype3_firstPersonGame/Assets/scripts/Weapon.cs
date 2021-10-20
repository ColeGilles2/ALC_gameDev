using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject bulletProjectile;
    public Transform muzzle;
    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;
    public float bulletSpeed;
    public float shootRate;
    public float lastShootTime;
    public bool isPlayer;
    
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
        curAmmo = curAmmo - 1;

        // create bullet
        GameObject bullet = Instantiate(bulletProjectile, muzzle.position, muzzle.rotation);

        //set volicty of bulletprojectile
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }



}

