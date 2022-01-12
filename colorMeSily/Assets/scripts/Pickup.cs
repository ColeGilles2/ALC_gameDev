using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public GameObject player;
    public PlayerMovement playerMovement;

    public GameObject[] colors;

    private string color;

    public int whatColor;

    private Vector3 pos;

    void Awake() {
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

        transform.position = new Vector3(Random.Range(-9.5f, 9.5f),Random.Range(-4.5f, 4.5f),0);

        whatColor = Random.Range(0, 3);
        if (whatColor == 0) {
            color  = "red";
            for (int i = 0; i < colors.Length; i ++) {
                colors[i].SetActive(false);
            }
            colors[whatColor].SetActive(true);
        } else if (whatColor == 1) {
            color = "blue";
            for (int i = 0; i < colors.Length; i ++) {
                colors[i].SetActive(false);
            }
            colors[whatColor].SetActive(true);
        } else if (whatColor == 2) {
            color = "green";
            for (int i = 0; i < colors.Length; i ++) {
                colors[i].SetActive(false);
            }
            colors[whatColor].SetActive(true);
        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            playerMovement.color = color;
            Destroy(gameObject);
        }
    }
}
