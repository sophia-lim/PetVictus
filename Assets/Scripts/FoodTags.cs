using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodTags : MonoBehaviour {

    public Text veggieCount;
    public Text meatCount;
    public Text dairyCount;
    public Text seafoodCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
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

    // Increments the public post veggie count
    public void increaseMeatCount() {
        Debug.Log("Clicked meat.");
        saveManager.Instance.state.postMeatCount++;
        saveManager.Instance.Save();
        Debug.Log("Current post meat count: " + saveManager.Instance.state.postMeatCount);
    }

    // Increments the public post veggie count
    public void increaseDairyCount() {
        Debug.Log("Clicked dairy.");
        saveManager.Instance.state.postDairyCount++;
        saveManager.Instance.Save();
        Debug.Log("Current post veggie count: " + saveManager.Instance.state.postVeggieCount);
    }

    // Increments the public post veggie count
    public void increaseSeafoodCount() {
        Debug.Log("Clicked seafood.");
        saveManager.Instance.state.postSeafoodCount++;
        saveManager.Instance.Save();
        Debug.Log("Current post seafood count: " + saveManager.Instance.state.postSeafoodCount);
    }
}
