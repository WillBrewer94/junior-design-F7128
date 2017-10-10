using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    TouchInputManager tm;
    PlayerController playerController;

    // Singleton Code
    void Awake() {
        if(instance == null) {
            instance = this;
            tm = new TouchInputManager();
            Debug.Log("GameManager Singleton Created");

        } else if(instance != this) {
            Destroy(gameObject);
        }

        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    void Update() {
        //Load initial scene
    }
}
