using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputManager {

    // Added a redundant enum for control type, not sure
    // if android vs iOS has different touch screen behavior
    public enum ControlType { Android, OSX }
    public enum OperatingSystem { Android, OSX };

    public OperatingSystem currentOS;

    public TouchInputWrapper playerControl;

    // Singleton instance
    public static TouchInputManager instance;

    public TouchInputManager() {
        SetupPlatform();
        if(instance != this) {
            instance = this;
        }
        //Sets default as iPhone control wrapper
        playerControl = new IphoneTouchWrapper();

        Debug.Log("Touch Input Manager Instantiated");
    }

    private void SetupPlatform() {
        if (Application.platform == RuntimePlatform.Android) {
            currentOS = OperatingSystem.Android;
        } else {
            currentOS = OperatingSystem.OSX;
        }

        Debug.Log("OS Set Up: " + currentOS.ToString());
    }

    // Clears the active player touch controller
    public void ClearPlayer() {
        playerControl = null;
    }

    // Registers a new player touch controller
    public void RegisterPlayerTouch(TouchInputWrapper tiw) {
        playerControl = tiw;
        Debug.Log(tiw.GetType().ToString() + ": Registered");
    }

    // Returns the current control type of the player
    public ControlType PlayerControlType() {
        if(playerControl.Equals(typeof(iPhoneControllerWrapper))) {
            Debug.Log("Type is correct: OSX");
            return ControlType.OSX;
        } else {
            return ControlType.OSX;
        }
    }

    public bool GetTap() {
        if(playerControl == null) {
            return false;
        }

        return playerControl.GetTap();
    }

    public bool GetTouchDown() {
        if(playerControl == null) {
            Debug.Log("Player controller not set up!");
            return false;
        }

        return playerControl.GetTouchDown();
    }

    public bool GetTouchUp() {
        if(playerControl == null) {
            return false;
        }

        return playerControl.GetTouchUp();
    }

    public bool GetSwipe() {
        if(playerControl == null) {
            return false;
        }

        return playerControl.GetSwipe();
    }

    public bool GetSwipeEnd(Touch touch) {
        throw new NotImplementedException();
    }

    public bool GetSwipeStart(Touch touch) {
        throw new NotImplementedException();
    }

    public override string ToString() {
        return currentOS.ToString();
    }
}
