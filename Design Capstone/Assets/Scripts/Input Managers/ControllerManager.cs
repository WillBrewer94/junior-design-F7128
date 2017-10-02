using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerID { None, One, Two };

public class ControllerManager : MonoBehaviour {

    public enum ControlType { None, Xbox, PS4, Keyboard , Touch };
    public enum OperatingSystem { Win, OSX, Linux, Android}

    public OperatingSystem currentOS;
    public Dictionary<PlayerID, ControllerInputWrapper> playerControls;

    public static ControllerManager instance;

    public ControllerManager() {
        SetUpPlatform();
        playerControls = new Dictionary<PlayerID, ControllerInputWrapper>();
        if(instance != this) {
            instance = this;
            Debug.Log("I did a thing!");
        }
    }

    public bool AddPlayer(ControllerInputWrapper.Buttons connectCode) {
        KeyboardWrapper kw = new KeyboardWrapper(-1);
        if(!playerControls.ContainsValue(kw) && kw.GetButton(connectCode)) {
            for(int j = 1; j < 5; j++) {
                if(!playerControls.ContainsKey((PlayerID)j)) {
                    RegisterPlayerController(j, kw);
                    return true;
                }
            }
        }

        if(playerControls.Count < 4) {
            string[] controllerNames = Input.GetJoystickNames();
            for(int i = 0; i < controllerNames.Length; i++) {
                ControllerInputWrapper ciw = GetControllerType(i);
                if(ciw != null && !playerControls.ContainsValue(ciw) && ciw.GetButton(connectCode)) {
                    for(int j = 1; j < 5; j++) {
                        if(!playerControls.ContainsKey((PlayerID)j)) {
                            RegisterPlayerController(j, ciw);
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }

    // Registers a player given an ID and controller type
	private void RegisterPlayerController(int id, ControllerInputWrapper ciw) {
        playerControls.Add((PlayerID)(id), ciw);
        Debug.Log((PlayerID)(id) + ": " + ciw + " added");
    }

    public float GetAxis(ControllerInputWrapper.Axis axis, PlayerID id, bool isRaw = false) {
        if(!playerControls.ContainsKey(id)) return 0;
        if(playerControls[id] == null) {
            return 0;
        }
        return playerControls[id].GetAxis(axis, isRaw);
    }

    public float GetTrigger(ControllerInputWrapper.Triggers trigger, PlayerID id, bool isRaw = false) {
        if(!playerControls.ContainsKey(id)) return 0;
        if(playerControls[id] == null) {
            return 0;
        }
        return playerControls[id].GetTrigger(trigger, isRaw);
    }

    public bool GetButton(ControllerInputWrapper.Buttons button, PlayerID id = PlayerID.One) {
        if(!playerControls.ContainsKey(id)) return false;
        if(playerControls[id] == null) {
            return false;
        }
        return playerControls[id].GetButton(button);
    }

    public bool GetButtonDown(ControllerInputWrapper.Buttons button, PlayerID id = PlayerID.One) {
        if(!playerControls.ContainsKey(id)) return false;
        if(playerControls[id] == null) {
            return false;
        }
        return playerControls[id].GetButtonDown(button);
    }

    public bool GetButtonUp(ControllerInputWrapper.Buttons button, PlayerID id = PlayerID.One) {
        if(!playerControls.ContainsKey(id)) return false;
        if(playerControls[id] == null) {
            return false;
        }
        return playerControls[id].GetButtonUp(button);
    }

    //Detects and sets up the current operating system
    private void SetUpPlatform() {
        if(Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXWebPlayer
            || Application.platform == RuntimePlatform.OSXEditor) {
            currentOS = OperatingSystem.OSX;
        } else {
            currentOS = OperatingSystem.Win;
        }
    }

    public ControllerInputWrapper GetControllerType(int joyNum) {
        string[] controllerNames = Input.GetJoystickNames();
        if(joyNum < 0 || joyNum > controllerNames.Length) {
            return null;
        }
     
        string name = controllerNames[joyNum];

        if(name.Contains("Wireless")) {
            return new PS4ControllerWrapper(joyNum);
        } else {
            return new PS4ControllerWrapper(joyNum);
        }
    }

    public override string ToString() {
        return currentOS.ToString();
    }
}
