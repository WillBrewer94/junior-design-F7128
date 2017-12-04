using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingManager : MonoBehaviour {
    public float TARGET_WIDTH;
    public float TARGET_HEIGHT;
    public int PIXELS_TO_UNITS;

	// Use this for initialization
	void Start () {
        float desiredRatio = TARGET_WIDTH / TARGET_HEIGHT;
        float currentRatio = (float)Screen.width / (float)Screen.height;

        if(currentRatio >= desiredRatio) {
            Camera.main.orthographicSize = TARGET_HEIGHT / 4 / PIXELS_TO_UNITS;
        } else {
            float sizeDiff = desiredRatio / currentRatio;
            Camera.main.orthographicSize = TARGET_HEIGHT / 4 / PIXELS_TO_UNITS * sizeDiff;
        }
        Debug.Log("Bleh");
        Debug.Log("Ortho set to " + Camera.main.orthographicSize);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
