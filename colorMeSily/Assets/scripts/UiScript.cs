using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScript : MonoBehaviour {

    public GameObject[] hearts;

    public int lives;

    // Start is called before the first frame update
    void Start() {
        lives = 3;
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < hearts.Length; i++) {
            hearts[i].SetActive(false);
        }
        for (int i = 0; i < lives; i++) {
            hearts[i].SetActive(true);
        }
    }
}
