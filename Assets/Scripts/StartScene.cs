using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // On button click : check if it is the first time playing
    // If first time: go to accountCreation
    // If not first time : go to main
    public void startGame() {
        if (saveManager.Instance.state.firstTime == true) {
            SceneManager.LoadScene("registration");
        } else {
            SceneManager.LoadScene("main");
        }

    }
}
