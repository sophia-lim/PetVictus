using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Main : MonoBehaviour {

    public Text veggieCount;
    public Text meatCount;
    public Text seafoodCount;
    public Text dairyCount;

    //public Text currentMood;
    public Text petName;

	// Use this for initialization
	void Start () {
        displayInformation();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void displayInformation() {
        veggieCount.text = saveManager.Instance.state.totalVeggieCount.ToString();
        meatCount.text = saveManager.Instance.state.totalMeatCount.ToString();
        seafoodCount.text = saveManager.Instance.state.totalSeafoodCount.ToString();
        dairyCount.text = saveManager.Instance.state.totalDairyCount.ToString();
        //currentMood.text = saveManager.Instance.state.currentMood;
        petName.text = saveManager.Instance.state.petName;
    }
}
