using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class BattleManager : MonoBehaviour {
    public float offset;
    public Dictionary<string, Vector2> swipeTypes;
    TouchControl input;
    Vector2 touchStart;
    Vector2 touchEnd;

	// Use this for initialization
	void Start () {
        touchStart = Vector2.zero;
        touchEnd = Vector2.zero;
        swipeTypes = new Dictionary<string, Vector2>();

        //Initialize Dictionary
        swipeTypes.Add("Up", Vector2.up);
        swipeTypes.Add("Down", Vector2.down);
        swipeTypes.Add("Left", Vector2.left);
        swipeTypes.Add("Right", Vector2.right);
    }
	
	// Update is called once per frame
	void Update () {
        if(RecordSwipe()) {
            CheckSwipe(touchStart, touchEnd, offset);
        }
	}

    /// <summary>
    /// Returns a bool representing whether a swipe was detected or not
    /// True if swipe was detected, false otherwise
    /// </summary>
    public bool RecordSwipe() {
        if(TouchManager.TouchCount > 0) {
            InControl.Touch touch = TouchManager.GetTouch(0);

            //Record starting position of touch
            if(touch.phase == TouchPhase.Began) {
                touchStart = touch.position;
            } 
            else if(touch.phase == TouchPhase.Ended) {
                touchEnd = touch.position;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Returns a vector representing the normalized swipe direction, returns a zero vector if no touch
    /// </summary>
    /// <param name="start">The swipe starting position</param>
    /// /// <param name="end">The swipe ending position</param>
    public Vector2 CheckSwipe(Vector2 start, Vector2 end, float offset) {
        Vector2 swipeDir = new Vector2(end.x - start.x, end.y - start.y).normalized;

        foreach(var key in swipeTypes.Keys) {
            Vector2 swipeTypeDir = swipeTypes[key];
            Vector2 accuracy = new Vector2(swipeDir.x - swipeTypeDir.x, swipeDir.y - swipeTypeDir.y);
            float mag = accuracy.magnitude;

            Debug.Log("Swipe Type: " + key + ", " + swipeTypeDir);
            Debug.Log("Recorded Swipe: " + swipeDir);
            Debug.Log("Difference: " + mag);

            if(mag <= offset) {
                Debug.Log(key + " swipe detected!");
                return swipeTypeDir;
            } 
        }

        return Vector2.zero;
    }
}
