using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorController : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playAnim() == true) {
            anim.SetBool("play", true);
        } else {
            anim.SetBool("play", false);
        }
	}

    public bool playAnim() {
        return true;
    }

}
