using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculateMood : MonoBehaviour {

    private int totalFoodTagged;
    public Text displayedCurrentMood;

    // Use this for initialization
    void Start () {

        Debug.Log("hiiiiiiiiiiiii");
        if (calculateTotalFoodTagged() == 0) {
            // Happy by default
            Debug.Log("Default mood");
            saveManager.Instance.state.currentMood = "Happy";
            displayedCurrentMood.text = saveManager.Instance.state.currentMood;
            //Debug.Log(saveManager.Instance.state.currentMood);
        } else {
            calculateCurrentMood();
            Debug.Log("Calculated mood");
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    private int calculateTotalFoodTagged() {
        totalFoodTagged = saveManager.Instance.state.totalVeggieCount + saveManager.Instance.state.totalMeatCount + saveManager.Instance.state.totalDairyCount + saveManager.Instance.state.totalSeafoodCount;
        return totalFoodTagged;
        //return 0;
    }

    private float calculateVeggiePercent() {
        float veggieWeight = saveManager.Instance.state.totalVeggieCount / totalFoodTagged;
        return veggieWeight;
        //return 0.00f;
    }

    private float calculateMeatPercent() {
        float meatWeight = saveManager.Instance.state.totalMeatCount / totalFoodTagged;
        return meatWeight;
        //return 0.75f;
    }

    private float calculateDairyPercent() {
        float dairyWeight = saveManager.Instance.state.totalDairyCount / totalFoodTagged;
        return dairyWeight;
        //return 0.00f;
    }

    private float calculateSeafoodPercent() {
        float seafoodWeight = saveManager.Instance.state.totalSeafoodCount / totalFoodTagged;
        return seafoodWeight;
        //return 0.00f;
    }

    private void calculateCurrentMood() {
        if (calculateVeggiePercent() > 0.75f) {
            // Ecstatic if eating more than 75% veggies
            displayedCurrentMood.text = (string)saveManager.Instance.state.moods[1];

        } else if (calculateVeggiePercent() < 0.25f) {
            // Unhappy if eating less than 25% veggies
            displayedCurrentMood.text = (string)saveManager.Instance.state.moods[7];

        } else if (calculateVeggiePercent() > 0.40f && calculateDairyPercent() > 0.30f) {
            // Happy if eating above 40% veggies and above 30% dairy
            displayedCurrentMood.text = (string)saveManager.Instance.state.moods[2];

        } else if (calculateVeggiePercent() > 0.40f && calculateSeafoodPercent() > 0.30f) {
            // Content if eating above 40% veggies and above 30% seafood
            displayedCurrentMood.text = (string)saveManager.Instance.state.moods[3];

        } else if (calculateDairyPercent() > 0.40f && calculateSeafoodPercent() > 0.30f) {
            // Worried if eating above 40% dairy and above 30% seafood
            displayedCurrentMood.text = (string)saveManager.Instance.state.moods[4];

        } else if (calculateDairyPercent() > 0.70f) {
            // Sick if eating above 70% dairy 
            displayedCurrentMood.text = (string)saveManager.Instance.state.moods[5];

        } else if (calculateSeafoodPercent() > 0.70f) {
            // Alerted if eating above 70% seafood
            displayedCurrentMood.text = (string)saveManager.Instance.state.moods[6];

        } else if (calculateMeatPercent() > 0.50f) {
            // Angry if eating above 50% meat
            displayedCurrentMood.text = (string)saveManager.Instance.state.moods[8];
        }

        saveManager.Instance.state.currentMood = displayedCurrentMood.text;
        saveManager.Instance.Save();
    }
}
