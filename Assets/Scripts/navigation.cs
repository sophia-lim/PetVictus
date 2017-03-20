using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navigation : MonoBehaviour {

    private Vector3 panelPosition;
    private int currentPanel = 0;

    public RectTransform mainPanel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mainPanel.anchoredPosition3D = Vector3.Lerp(mainPanel.anchoredPosition3D, panelPosition, 0.1f);
    }

    //Checks current panel and which panel to go, move to panel, and update current panel index
    private void changePanelPosition(int panelIndex) {
        Debug.Log("The current panel is:" + currentPanel);

        if (currentPanel == 0 && panelIndex == 1) {
            Debug.Log("Going to Edit");
            panelPosition = Vector3.left * 1440;
        } else if (currentPanel == 1 && panelIndex == 0) {
            Debug.Log("Going to Capture");
            panelPosition = Vector3.right * 0;
        } else if (currentPanel == 1 && panelIndex == 2) {
            Debug.Log("Going to Confirm");
            panelPosition = Vector3.left * 2880;
        } else if (currentPanel == 2 && panelIndex == 1) {
            Debug.Log("Going to Register 2");
            panelPosition = Vector3.left * 1440;
        }

        currentPanel = panelIndex;
        Debug.Log("The updated panel is:" + currentPanel);
    }

    //Move to capture panel
    public void goToPanelCapture() {
        changePanelPosition(0);
    }

    //Move to edit panel
    public void goToPanelEdit() {
        changePanelPosition(1);
    }

    //Move to mood panel
    public void goToPanelMood() {
        changePanelPosition(2);
    }
}
