using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int scoreToWin;
    public int curScore;

    public bool gamePaused;
    public static GameManager instance;

    void Awake() {
        //instance of script
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Cancel")) {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame() {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        GameUI.instance.TogglePauseMenu(gamePaused);

        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public  void WinGame() {
        GameUI.instance.SetEndGameScreen(true, curScore);
    }
    public void LoseGame() {
        GameUI.instance.SetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }
}
//stioo
