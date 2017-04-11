using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveManager : MonoBehaviour {

    // So you can access the save state anywhere in the game or when you want to quickly save on the go.
    public static saveManager Instance { set; get; }
    public saveState state;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();
    }
    
    // Save the whole state of this saveState script to the player pref
    public void Save() {
        //Serialize Save State
        PlayerPrefs.SetString("save", helper.Serialize<saveState>(state));
    }

    // Load the previous save state from the player prefs
    public void Load() {
        if (PlayerPrefs.HasKey("save")) {
            // Deserialize Save State
            state = helper.Deserialize<saveState>(PlayerPrefs.GetString("save"));
            Debug.Log("State loaded");

        } else {
            state = new saveState();
            Save();
            Debug.Log("No Save File found creating a new one");
        }
    }
    
    /*Attempt buying equipment, return true/ false 
    public bool BuyEquip(int index, int cost) {
        if (state.gold >= cost) {
            //enough money, remove the amount from the current gold stack.
            state.gold -= cost;
            UnlockEquipment(index);

            // Save progress & changes made.
            Save();

            return true;
        } else {
            // Not enough monwy, return false
            return false;
        }
    }*/

    public bool confirmPostCreation() {

        return true;
    }
    

    // Reset the whole save file
    public void ResetSave() {
        PlayerPrefs.DeleteKey("save");
    }
}
