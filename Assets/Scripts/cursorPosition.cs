using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorPosition : MonoBehaviour {

    //Cursor
    float menuPosX;
    float menuPosY;

    //UI
    public GameObject tags;
    float widthMenu = 400f;
    float heightMenu = 100f;

    //Interactable area
    int bottomArea = 380;
    int topArea = 1820; 

    //Active area UI
    bool hideMenu;

	// Use this for initialization
	void Start () {
        Debug.Log("Setting active to false.");
        tags.SetActive(false);
    }

    public void handleCanvasClick() {
        // show menu if not shown
        if (!tags.activeSelf) {
            Debug.Log(tags.activeSelf);
            Debug.Log("Set tags to active.");
   //       if (bottomArea < Input.mousePosition.y && Input.mousePosition.y < topArea) {
            tags.SetActive(true);
                tags.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                menuPosX = Input.mousePosition.x;
            menuPosY = Input.mousePosition.y;
            Debug.Log("Menu pos X:" + menuPosX);
            Debug.Log("Menu pos Y:" + menuPosY);
            //       }
        } else {
            Debug.Log(tags.activeSelf);
            Debug.Log("Set tags to inactive");
            if (((Input.mousePosition.x > menuPosX + widthMenu / 2) || (Input.mousePosition.x < menuPosX - widthMenu / 2)) || ((Input.mousePosition.y > menuPosY + heightMenu / 2) || (Input.mousePosition.y < menuPosY - heightMenu / 2))) {
                tags.SetActive(false);
            }
        }
    }
}
