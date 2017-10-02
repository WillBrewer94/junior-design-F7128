using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS4ControllerWrapper : ControllerInputWrapper {

    public PS4ControllerWrapper(int joyNum) : base(joyNum) {

    }

    public override float GetAxis(Axis axis, bool isRaw = false) {
        float scale = 1;
        string axisName = "";

        switch(axis) {
            case Axis.LeftStickX:
                axisName = GetAxisName("X", "X", "X");
                break;
            case Axis.LeftStickY:
                axisName = GetAxisName("Y", "Y", "Y");
                scale = -1;
                break;
            case Axis.RightStickX:
                axisName = GetAxisName("3", "3", "3");
                break;
            case Axis.RightStickY:
                axisName = GetAxisName("6", "4", "4");
                scale = -1;
                break;
            case Axis.DPadX:
                axisName = GetAxisName("7", "7", "7");
                break;
            case Axis.DPadY:
                axisName = GetAxisName("8", "8", "8");
                if(ControllerManager.instance.currentOS != ControllerManager.OperatingSystem.Win)
                    scale = -1;
                break;
        }

        if(isRaw) {
            return Input.GetAxisRaw(axisName) * scale;
        } else {
            return Input.GetAxis(axisName) * scale;
        }
    }

    public override bool GetButton(Buttons button) {
        string buttonName = GetButtonHelper(button);
        if(buttonName != null) {
            return Input.GetButton(buttonName);
        }
        return false;
    }

    public override bool GetButtonDown(Buttons button) {
        string buttonName = GetButtonHelper(button);
        if(buttonName != null) {
            return Input.GetButtonDown(buttonName);
        }
        return false;
    }

    public override string GetButtonHelper(Buttons button) {
        string buttonName = "";
        switch(button) {
            case Buttons.A:
                buttonName = GetButtonName("1", "1", "1");
                break;
            case Buttons.B:
                buttonName = GetButtonName("2", "2", "2");
                break;
            case Buttons.X:
                buttonName = GetButtonName("0", "0", "0");
                break;
            case Buttons.Y:
                buttonName = GetButtonName("3", "3", "3");
                break;
            case Buttons.LeftBumper:
                buttonName = GetButtonName("4", "4", "4");
                break;
            case Buttons.RightBumper:
                buttonName = GetButtonName("5", "5", "5");
                break;
            case Buttons.LeftStickClick:
                buttonName = GetButtonName("10", "10", "10");
                break;
            case Buttons.RightStickClick:
                buttonName = GetButtonName("11", "11", "11");
                break;
            case Buttons.Start:
                buttonName = GetButtonName("9", "9", "9");
                break;
            case Buttons.Back:
                buttonName = GetButtonName("8", "8", "8");
                break;
        }
        return buttonName;
    }

    public override bool GetButtonUp(Buttons button) {
        string buttonName = GetButtonHelper(button);

        return Input.GetButtonUp(buttonName);
    }

    public override float GetTrigger(Triggers trigger, bool isRaw = false) {
        string triggerName = "";
        switch(trigger) {
            case Triggers.LeftTrigger:
                triggerName = GetAxisName("4", "5", "5");
                break;
            case Triggers.RightTrigger:
                triggerName = GetAxisName("5", "6", "6");
                break;
        }
        if(isRaw) {
            return Input.GetAxisRaw(triggerName);
        }
        return Input.GetAxis(triggerName);
    }
}
