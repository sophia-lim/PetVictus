using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class mealRawImage : MonoBehaviour {
    public Material savedImageMaterial;
    public Texture savedImageTexture;

    public bool creatingFile = false;
    public string captureButton = "captureButton";
    public Text path;
    public string stringPath;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (creatingFile) {
        //    string origin = System.IO.Path.Combine(Application.persistentDataPath, fileName());
        //    string destination = ""
        //}
	}

    //Returns filename modified with date and time
    string fileName() {
        return string.Format("/screen_{0}.png",
                              System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    public void takePicture() {
        Application.CaptureScreenshot(Application.persistentDataPath + fileName());
        //creatingFile = true;
        Debug.Log(Application.persistentDataPath);
        Debug.Log(Application.persistentDataPath + fileName());
        stringPath = Application.persistentDataPath + fileName();
        stringPath = path.text;
    }

    private void createNewTexture() {
        //savedImageTexture = Resources.Load(fileName(1440, 2560)) as Texture;
        //gameObject.GetComponent<Renderer>().material.mainTexture = savedImageTexture;
    }
}
