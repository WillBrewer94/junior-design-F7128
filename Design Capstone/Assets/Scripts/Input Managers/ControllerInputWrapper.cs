using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ControllerInputWrapper.cs
// General wrapper class to support different controller inputs

public abstract class ControllerInputWrapper : MonoBehaviour {

    //Button Enums
    public enum Axis { LeftStickY, LeftStickX, RightStickY, RightStickX, DPadY, DPadX };
    public enum Buttons { A, B, X, Y, RightBumper, LeftBumper, Back, Start, LeftStickClick, RightStickClick, Key_1, Key_2, Key_3, Key_4, Key_Fire, Key_Confirm };
    public enum Triggers { RightTrigger, LeftTrigger };

    // Abstract Methods
    public abstract bool GetButton(Buttons button);

    public abstract bool GetButtonDown(Buttons button);

    public abstract bool GetButtonUp(Buttons button);

    public abstract float GetAxis(Axis axis, bool isRaw = false);

    public abstract float GetTrigger(Triggers trigger, bool isRaw = false);

    public abstract string GetButtonHelper(Buttons button);

    // Controller number
    protected int joyNum;

    public ControllerInputWrapper(int joyNum) {
        this.joyNum = joyNum;
    }

    public override bool Equals(object obj) {
        if(obj == null) {
            return false;
        }

        ControllerInputWrapper test = obj as ControllerInputWrapper;
        if((System.Object)test == null) {
            return false;
        }

        if(test.joyNum == this.joyNum) {
            return true;
        }

        return false;
    }

    public override int GetHashCode() {
        return base.GetHashCode();
    }

    //Returns the button name as a string
    protected virtual string GetButtonName(string winID, string linID, string osxID) {
        string buttonName = "j" + (joyNum + 1) + "_Button";

        switch(ControllerManager.instance.currentOS) {
            case ControllerManager.OperatingSystem.Win:
                return buttonName + winID;
            case ControllerManager.OperatingSystem.Linux:
                return buttonName + linID;
            case ControllerManager.OperatingSystem.OSX:
                return buttonName + osxID;
            default:
                return null;
        }
    }

    // Returns the axis name as a string
    protected virtual string GetAxisName(string winID, string linID, string osxID) {
        string axisName = "j" + (joyNum + 1) + "_Axis";

        switch(ControllerManager.instance.currentOS) {
            case ControllerManager.OperatingSystem.Win:
                return axisName + winID;
            case ControllerManager.OperatingSystem.Linux:
                return axisName + linID;
            case ControllerManager.OperatingSystem.OSX:
                return axisName + osxID;
            default:
                return null;
        }
    }
}
