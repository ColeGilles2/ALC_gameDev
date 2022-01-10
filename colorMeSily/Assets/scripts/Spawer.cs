using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawer : MonoBehaviour {

    public GameObject enemy;

    // Start is called before the first frame update
    void Start() {
        Instantiate(enemy);
        Instantiate(enemy);
        Instantiate(enemy);
        Instantiate(enemy);
        Instantiate(enemy);
        Instantiate(enemy);
        Instantiate(enemy);

        Instantiate(enemy);
        Instantiate(enemy);
        Instantiate(enemy);
        Instantiate(enemy);

        Instantiate(enemy);
        Instantiate(enemy);

        Instantiate(enemy);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
