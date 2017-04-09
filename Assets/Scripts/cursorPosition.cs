using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorPosition : MonoBehaviour {

    //Cursor
    float cursorPosX;
    float cursorPosY;
    bool hasUpdated;

    //UI
    public GameObject tags;
    bool onMenu;
    float widthMenu = 400f;
    float heightMenu = 100f;

    //Active area UI
    bool hideMenu;

	// Use this for initialization
	void Start () {
        hasUpdated = false;
        onMenu = false;
        hideMenu = false;
        tags.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (hasUpdated) {
            Debug.Log("The pos X is: " + cursorPosX.ToString());
            Debug.Log("The pos Y is: " + cursorPosY.ToString());
            hasUpdated = false;
        }
        displayTags();
        hideTags();
    }

    //Updates the values of the vector 2D of cursor position only if changed
    public void getCursorPosition() {
        if (cursorPosX == Input.mousePosition.x && cursorPosY == Input.mousePosition.y) {
            hasUpdated = false;
        } else {
            cursorPosX = Input.mousePosition.x;
            cursorPosY = Input.mousePosition.y;
            hasUpdated = true;
            onMenu = true;
        }
    }

    //Displays the UI with the meal tags
    private void displayTags() {
        onMenu = true;
        tags.SetActive(true);
        tags.transform.position = new Vector2(cursorPosX, cursorPosY);
    }

    //Click outside of area
    public void outsideActiveArea() {
        if (onMenu) {
            if ( ((Input.mousePosition.x > cursorPosX+widthMenu/2) || (Input.mousePosition.x < cursorPosX - widthMenu / 2)) && ((Input.mousePosition.y > cursorPosY + heightMenu / 2) || (Input.mousePosition.y < cursorPosY - heightMenu / 2)) ) {
                Debug.Log("Outside of menu area.");
                hideMenu = true;
            }
        }
    }

    //Hides the UI with the meal tags
    private void hideTags() {
        if (hideMenu) {
            tags.SetActive(false);
        }
    }
}
