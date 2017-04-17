using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour {

    // Landing Scene
    public void goToStart() {
        SceneManager.LoadScene("start");
    }

    // Main page: with pet name and current mood
    // Contains navigation to other scenes
    public void goToMain() {
        SceneManager.LoadScene("main");
    }

    // Create new post scene
    public void goToPostCreate() {
        SceneManager.LoadScene("post_create");
    }

    // Tag new post scene
    public void goToPostEdit() {
        SceneManager.LoadScene("post_edit");
    }

    // Tag new post scene
    public void goToRegistration() {
        SceneManager.LoadScene("registration");
    }

    // Exit game
    public void exitGame() {
        Application.Quit();
    }
}
