using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phoneCamera : MonoBehaviour {
    
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;

    //public Material savedImageMaterial;
    //public Texture savedImageTexture;
    
    public RawImage background;
    public AspectRatioFitter fit;

    public bool isCapturedImgOn;
    public Image capturedImage;
    public bool cameraOn;

    private void Start() {

        //Camera setup (24 - 50)
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

}
