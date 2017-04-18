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
    
	}

    // To put on button
    public void actionKick() {
        anim.Play("kick");
        anim.SetBool("kick", true);
    }

    // To put on button
    public void actionShower() {
        anim.Play("shower");
        anim.SetBool("shower", true);
    }

    // To put on button
    public void actionEat() {
        anim.Play("eat");
        anim.SetBool("eat", true);
    }

}
