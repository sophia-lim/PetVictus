using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculateMood : MonoBehaviour {

    public int numberVeggies;
    public int numberMeat;
    public int numberDairy;
    public int numberSeafood;

    public Text textNumVeggies;
    public Text textNumMeat;
    public Text textNumDairy;
    public Text textNumSeafood;

    // Use this for initialization
    void Start () {
        numberVeggies = 0;
        numberMeat = 0;
        numberDairy = 0;
        numberSeafood = 0;
	}
	
	// Update is called once per frame
	void Update () {
        textNumVeggies.text = numberVeggies.ToString();
        textNumMeat.text = numberMeat.ToString();
        textNumDairy.text = numberDairy.ToString();
        textNumSeafood.text = numberSeafood.ToString();
	}
    
    public void incrementVeggies() {
        numberVeggies++;
    }

    public void incrementMeat() {
        numberMeat++;
    }

    public void incrementDairy() {
        numberDairy++;
    }

    public void incrementSeafood() {
        numberSeafood++;
    }
}
