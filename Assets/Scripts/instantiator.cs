using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;

public class instantiator : MonoBehaviour {

	public UnityEngine.Object prefab;
	public Transform parent;
	public GameObject animControllerScript;
    private Animator anim;

    public GameObject dog;
    public GameObject cow;
    public GameObject pig;
    public GameObject sheep;

    // Use this for initialization
    void Start () {

        dog.SetActive(false);
        cow.SetActive(false);
        pig.SetActive(false);
        sheep.SetActive(false);

        if (saveManager.Instance.state.petType == "dog") {
            dog.SetActive(true);
            anim = dog.GetComponent<Animator>();
          
        } else if (saveManager.Instance.state.petType == "cow") {
            cow.SetActive(true);
            anim = cow.GetComponent<Animator>();

        } else if (saveManager.Instance.state.petType == "pig") {
            pig.SetActive(true);
            anim = pig.GetComponent<Animator>();

        } else if (saveManager.Instance.state.petType == "sheep") {
            sheep.SetActive(true);
            anim = sheep.GetComponent<Animator>();

        }

            // Load specific animal
        //    loadPrefab(saveManager.Instance.state.petType);
        //GameObject clone = Instantiate(prefab,parent) as GameObject;

        //RuntimeAnimatorController rac = AssetDatabase.LoadAssetAtPath("Assets/Graphics/Models/animator.controller", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        //RuntimeAnimatorController rac = Resources.Load("animator.controller", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        //debug.text = rac.ToString(); 
       // clone.GetComponent<Animator>().runtimeAnimatorController = rac;
        //anim = GetComponent<Animator>();
        //clone.AddComponent<animatorController>();

        /*MissingComponentException: There is no 'Animator' attached to the "sheep(Clone)" game object, but a script is trying to access it.
        You probably need to add a Animator to the game object "sheep(Clone)". Or your script needs to check if the component is attached before using it.
        instantiator.Start () (at Assets/Scripts/instantiator.cs:19)v*/

    }

    // Update is called once per frame
    void Update () {

    }

    private void loadPrefab(string petType) {
        prefab = Resources.Load(petType + ".fbx", typeof(GameObject)) as GameObject;

        //debug.text = prefab.ToString();
        //prefab = AssetDatabase.LoadAssetAtPath("Assets/Graphics/Models/" + petType + ".fbx", typeof(GameObject));
        Debug.Log ("Loaded prefab");
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
