using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupSpawner : MonoBehaviour {

    public GameObject player;

    public GameObject pickup;
    public PlayerMovement playerMovement;

    public float spawn;
    public float spawnMaster;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

        spawnMaster = 2.5f;
        spawn = spawnMaster;
    }

    // Update is called once per frame
    void FixedUpdate() {
       if (spawn > 0.1f) {
           spawn -= Time.deltaTime;
       } else {
           Instantiate(pickup);
           spawn = spawnMaster;
       }
    }
}
