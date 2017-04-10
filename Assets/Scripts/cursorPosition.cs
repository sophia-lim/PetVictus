using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorPosition : MonoBehaviour {

    //Cursor
    float menuPosX;
    float menuPosY;
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
        /*hasUpdated = false;
        onMenu = false;
        hideMenu = false;
        */
        tags.SetActive(false);
    }
	
	// Update is called once per frame
	/*void Update () {
        if (hasUpdated && !hideMenu) {
            Debug.Log("The pos X is: " + cursorPosX.ToString());
            Debug.Log("The pos Y is: " + cursorPosY.ToString());
            hasUpdated = false;
            hideMenu = false;
        }

        displayTags();
        //hideTags();
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
        Debug.Log("Display menu.");
        onMenu = true;
        tags.SetActive(true);
        tags.transform.position = new Vector2(cursorPosX, cursorPosY);
        outsideActiveArea();
    }

    //Click outside of area closes tag menu
    private void outsideActiveArea() {
        if (onMenu) {
            if ( ((Input.mousePosition.x > cursorPosX+widthMenu/2) || (Input.mousePosition.x < cursorPosX - widthMenu / 2)) && ((Input.mousePosition.y > cursorPosY + heightMenu / 2) || (Input.mousePosition.y < cursorPosY - heightMenu / 2)) ) {
                Debug.Log("Outside of menu area.");
                hideMenu = true;
                hideTags();
            }
        } else {
            Debug.Log("Inside of menu area.");
        }
    }

    //Hides the UI with the meal tags
    private void hideTags() {
        if (hideMenu) {
            Debug.Log("Hide menu.");
            tags.SetActive(false);
        }
    }*/

    public void handleCanvasClick() {
        // show menu if not shown
        if (!tags.activeSelf) {
            tags.SetActive(true);
            tags.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            menuPosX = Input.mousePosition.x;
            menuPosY = Input.mousePosition.y;
        } else {
            if (((Input.mousePosition.x > menuPosX + widthMenu / 2) || (Input.mousePosition.x < menuPosX - widthMenu / 2)) || ((Input.mousePosition.y > menuPosY + heightMenu / 2) || (Input.mousePosition.y < menuPosY - heightMenu / 2))) {
                tags.SetActive(false);
            }
        }
    }
}
