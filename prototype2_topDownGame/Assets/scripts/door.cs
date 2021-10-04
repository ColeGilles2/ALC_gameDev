using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other) {
        
        //check for key and if it's player
        if (other.CompareTag("Player") && gameManager.hasKey == true) {
            print("you unlocked the door");
            gameManager.isDoorLocked = false;
        } else {
            print("door is locked you can't leave");
        }
    }

}
