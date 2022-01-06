using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject player;
    public PlayerMovement playerMovement;

    private float moveSpeed = 1.3f;
    private Vector3 pos;

    void Awake() {
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

        //pos = player.transform.position;
    }

    // Start is called before the first frame update
    void Start() {
        
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
            playerMovement.run = false;
            Destroy(player);
        }
    }
}
