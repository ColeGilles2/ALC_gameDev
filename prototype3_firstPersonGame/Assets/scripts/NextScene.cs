using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextScene : MonoBehaviour {

    private static int sceneOn = 0;

    public void ChangeScene() {
        sceneOn += 1;
        SceneManager.LoadScene(sceneOn);
        print(sceneOn);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            ChangeScene();
        }
    }

    public void Restart() {
        sceneOn = 0;
        SceneManager.LoadScene(sceneOn);
    }
}
