﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class phoneCamera : MonoBehaviour {
    //Camera variables
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;
    public RawImage background;
    public AspectRatioFitter fit;

    //Captured image variables
    public bool isCapturedImgOn;
    public Image capturedImage;
    public bool cameraOn;

    public GameObject newTags;
    public GameObject button;

    //public Image screenshot;

    private void Start() {
        newTags.SetActive(false);
        //Camera setup (26 - 52)
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0) {
            Debug.Log("No camera detected on mobile.");
            camAvailable = false;
            return;
        }

        //Go through array of cameras available on device
        for (int i = 0; i < devices.Length; i++) {
            if(!devices[i].isFrontFacing) {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        //Unable to find back-facing camera
        if (backCam == null) {
            Debug.Log("Unable to find a back camera");
            return;
        }

        backCam.Play();
        background.texture = backCam;

        camAvailable = true;

        //Captured image setup
        capturedImage.enabled = false;
        isCapturedImgOn = false;
        cameraOn = true;
    }

    private void Update() {
        if (!camAvailable) {
            return;
        }

        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        // If it is on a mirror side vertically, it is going to equal -1, if not it will equal 1
        float scaleY = backCam.videoVerticallyMirrored ? -1f: 1f;

        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        //Proper angle: Not sure I need it for the app since it's going to be square
        
        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);

        //If the camera is off, then load the captured image
        if (cameraOn == false) {
            capturedImage.enabled = true;
            isCapturedImgOn = true;
        }
    }

    //Close the camera on event trigger
    public void closeCamera() {
        if(backCam.isPlaying) {
            backCam.Stop();
            cameraOn = false;
        }
    }

    public void loadPostEditScene() {
        SceneManager.LoadScene("post_edit");
    }

    public void capture() {

        // NOTE - you almost certainly have to do this here:

        //yield return new WaitForEndOfFrame();

        // it's a rare case where the Unity doco is pretty clear,
        // http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
        // be sure to scroll down to the SECOND long example on that doco page 

        Texture2D photo = new Texture2D(backCam.width, backCam.height);
        photo.SetPixels(backCam.GetPixels());
        photo.Apply();
        button.SetActive(false);
        newTags.SetActive(true);
        //screenshot.GetComponent<Renderer>().material.mainTexture = photo;

        //Encode to a PNG
        //byte[] bytes = photo.EncodeToPNG();
        //Write out the PNG. Of course you have to substitute your_path for something sensible
        //File.WriteAllBytes(your_path + "photo.png", bytes);
    }
}
