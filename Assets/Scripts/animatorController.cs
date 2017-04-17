using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorController : MonoBehaviour {

    private Animator anim;
    private bool play;
    private bool played;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        play = false;
        played = false;
	}
	
	// Update is called once per frame
	void Update () {
    
	}

    // To put on button
    public void playAnim() {
        anim.Play("kick");
        anim.SetBool("play", true);
    }

}
