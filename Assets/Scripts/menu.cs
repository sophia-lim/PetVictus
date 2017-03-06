using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    
    // Update is called once per frame
    void Update () {

    }

    public void StartGame() {
        SceneManager.LoadScene("post_create");
    }

    public void Registration() {
        SceneManager.LoadScene("registration");
    }

    public void Login() {
        SceneManager.LoadScene("login");
    }

    public void Information() {
        SceneManager.LoadScene("information");
    }

    public void PostEdit() {
        SceneManager.LoadScene("post_edit");
    }

    public void ExitGame() {
        Application.Quit();
    }

}
