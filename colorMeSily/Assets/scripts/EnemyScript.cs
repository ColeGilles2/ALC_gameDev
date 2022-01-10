using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject player;
    public PlayerMovement playerMovement;

    private float moveSpeed = 1.3f;
    private Vector3 pos;

    public GameObject uiObject;
    public UiScript uiScript;

    public GameObject[] colors;

    private string color;

    void Awake() {
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

        uiObject = GameObject.FindWithTag("uiManager");
        uiScript = uiObject.GetComponent<UiScript>();

        transform.position = new Vector3(Random.Range(-10.0f, 10.0f),Random.Range(-6.0f, 6.0f),0);

        int whatColor = Random.Range(0, 4);
        if (whatColor == 1) {
            color  = "red";
            for (int i = 0; i < colors.Length; i ++) {
                colors[i].SetActive(false);
            }
            colors[whatColor].SetActive(true);
        } else if (whatColor == 2) {
            color = "blue";
            for (int i = 0; i < colors.Length; i ++) {
                colors[i].SetActive(false);
            }
            colors[whatColor].SetActive(true);
        } else if (whatColor == 3) {
            color = "green";
            for (int i = 0; i < colors.Length; i ++) {
                colors[i].SetActive(false);
            }
            colors[whatColor].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update() {
        if (playerMovement.run == true) {
            pos = player.transform.position;
            transform.position = Vector2.Lerp(transform.position, pos, moveSpeed * Time.deltaTime);      
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if(playerMovement.color == color) {
                Destroy(gameObject);
            } else {   
                if (uiScript.lives > 1) {
                    uiScript.lives -= 1;
                } else {
                    playerMovement.run = false;
                    uiScript.lives -= 1;
                    Destroy(player);
                }
            }
        }
    }
}
