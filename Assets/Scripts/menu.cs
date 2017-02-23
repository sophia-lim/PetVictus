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
        SceneManager.LoadScene("login");
    }


    public void ExitGame() {
        Application.Quit();
    }

}
