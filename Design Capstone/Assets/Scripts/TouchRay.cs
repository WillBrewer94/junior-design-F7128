using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TouchRay : MonoBehaviour {
    //Gameobjects
    public Text coordinates;
    float swipeSpeed = 0.1F;
    public Vector2 touchLoc;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if(Input.touchCount > 0) {
            touchLoc = Input.GetTouch(0).position;
            touchLoc = Camera.main.WorldToScreenPoint(touchLoc);
            coordinates.text = "X: " + touchLoc.x + " Y: " + touchLoc.y;
        }
    }
}
