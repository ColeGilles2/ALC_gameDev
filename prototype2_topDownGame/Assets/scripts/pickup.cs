using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class pickup : MonoBehaviour {

    public string pickupName = "The Key of Awesomeness";

    public int amount;

    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            gameManager.hasKey = true;
            print("you've picked up a " + pickupName);
            Destroy(gameObject);
        }
    }

}
