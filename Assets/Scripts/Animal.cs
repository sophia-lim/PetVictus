using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour {

    public string type;
    Animator animator;

    public Animal() {
        animator = GetComponent<Animator>();
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
