using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawer : MonoBehaviour {

    public GameObject enemy;

    public float spawn;
    public float spawnMaster;

    // Start is called before the first frame update
    void Start() {
        spawnMaster = 1.2f;
        spawn = spawnMaster;
       // Instantiate(enemy);
    }

    // Update is called once per frame
    void FixedUpdate() {
       if (spawn > 0.1f) {
           spawn -= Time.deltaTime;
       } else {
           Instantiate(enemy);
           spawn = spawnMaster;
       }
    }
}
