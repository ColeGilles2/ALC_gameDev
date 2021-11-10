using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage;
    public float lifeTime;
    private float shootTime;


    // Start is called before the first frame update
    void Start() {
        
    }

    void onEnable() {
        shootTime = Time.time;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
            other.GetComponent<Enemy>().TakeDamage(damage);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Time.time - shootTime >= lifeTime) {
            gameObject.SetActive(false);
        }
        
    }
}
