using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mealRawImage : MonoBehaviour {
    public Material savedImageMaterial;
    public Texture savedImageTexture;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Returns filename modified with date and time
    string fileName(int width, int height) {
        return string.Format("screen_{0}x{1}_{2}.png",
                              width, height,
                              System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    public void takePicture() {
        Application.CaptureScreenshot(Application.persistentDataPath + "/Resources/" + fileName(1440, 2560));
        Debug.Log(Application.persistentDataPath + "/Resources/" + fileName(1440, 2560));
    }

    private void createNewTexture() {
        savedImageTexture = Resources.Load(fileName(1440, 2560)) as Texture;
        //gameObject.GetComponent<Renderer>().material.mainTexture = savedImageTexture;
    }
}
