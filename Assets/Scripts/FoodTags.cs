using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FoodTags : MonoBehaviour {

    public Text veggieCount;
    public Text meatCount;
    public Text dairyCount;
    public Text seafoodCount;

	// Use this for initialization
	void Start () {
        //When beginning new post, set the counts back to zero
        saveManager.Instance.state.postVeggieCount = 0;
        saveManager.Instance.state.postMeatCount = 0;
        saveManager.Instance.state.postDairyCount = 0;
        saveManager.Instance.state.postSeafoodCount = 0;

    }
	
	// Update is called once per frame
    // Parse integer of veggie count to text
	void Update () {
        veggieCount.text = saveManager.Instance.state.postVeggieCount.ToString();
        meatCount.text = saveManager.Instance.state.postMeatCount.ToString();
        dairyCount.text = saveManager.Instance.state.postDairyCount.ToString();
        seafoodCount.text = saveManager.Instance.state.postSeafoodCount.ToString();
    }
    
    // Increments the public post veggie count
    public void increaseVeggieCount() {
        Debug.Log("Clicked veggie.");
        saveManager.Instance.state.postVeggieCount++;
        saveManager.Instance.Save();
        Debug.Log("Current post veggie count: " + saveManager.Instance.state.postVeggieCount);
    }

    // Increments the public post meat count
    public void increaseMeatCount() {
        Debug.Log("Clicked meat.");
        saveManager.Instance.state.postMeatCount++;
        saveManager.Instance.Save();
        Debug.Log("Current post meat count: " + saveManager.Instance.state.postMeatCount);
    }

    // Increments the public post dairy count
    public void increaseDairyCount() {
        Debug.Log("Clicked dairy.");
        saveManager.Instance.state.postDairyCount++;
        saveManager.Instance.Save();
        Debug.Log("Current post veggie count: " + saveManager.Instance.state.postVeggieCount);
    }

    // Increments the public post seafood count
    public void increaseSeafoodCount() {
        Debug.Log("Clicked seafood.");
        saveManager.Instance.state.postSeafoodCount++;
        saveManager.Instance.Save();
        Debug.Log("Current post seafood count: " + saveManager.Instance.state.postSeafoodCount);
    }

    // Add the post counts to the total count of foods
    // Save all counts
    // Load animal main scene
    public void confirmPost() {
        updateTotalFoodCounts();
        saveManager.Instance.Save();
        SceneManager.LoadScene("Main");
    }

    private void updateTotalFoodCounts() {
        saveManager.Instance.state.totalVeggieCount += saveManager.Instance.state.postVeggieCount;
        saveManager.Instance.state.totalMeatCount += saveManager.Instance.state.postMeatCount;
        saveManager.Instance.state.totalDairyCount += saveManager.Instance.state.postDairyCount;
        saveManager.Instance.state.totalSeafoodCount += saveManager.Instance.state.postSeafoodCount;
    }
}
