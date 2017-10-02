using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardWrapper : ControllerInputWrapper 
{

	public enum MouseControlMode {None, Drag, Offset};

	public static MouseControlMode mouseControlMode = MouseControlMode.Drag;

	private bool dragStarted;
	private Vector3 prevMousePos = Vector3.zero;
	private Vector2 dragDifference = Vector2.zero;

	public KeyboardWrapper(int joyNum) : base(joyNum)
    {
		
    }

    public override float GetAxis(Axis axis, bool isRaw = false)
    {
        string axisName = "";
        float scale = 1;
        Vector3 vec = Vector3.zero;
        switch (axis)
        {
            case Axis.LeftStickX:
                axisName = GetAxisName("Horizontal", "Horizontal", "Horizontal");
                break;
            case Axis.LeftStickY:
                axisName = GetAxisName("Vertical", "Vertical", "Vertical");
                break;
            case Axis.RightStickX:
                vec = retrieveMouseOffset();
                return vec.normalized.x;
            case Axis.RightStickY:
                vec = retrieveMouseOffset();
				return vec.normalized.y;
			case Axis.DPadX:
				axisName = GetAxisName("DPadX", "DPadX", "DPadX");
//				scale = 0.09f;
				break;
			case Axis.DPadY:
				axisName = GetAxisName("DPadY", "DPadY", "DPadY");
//				scale = 0.09f;
				break;
        }
        return Input.GetAxis(axisName) * scale;
    }

    Vector3 retrieveMouseOffset()
    {
		switch (mouseControlMode) {
			case MouseControlMode.None:
				return Vector3.zero;
			case MouseControlMode.Drag:
				if(Input.GetMouseButtonDown(0)) {
					prevMousePos = Input.mousePosition;
					dragStarted = true;
				} else if(!Input.GetMouseButton(0)) {
					dragStarted = false;
				}
				if(dragStarted) {
					dragDifference = new Vector2(Input.mousePosition.x - prevMousePos.x, Input.mousePosition.y - prevMousePos.y);
				} else {
					dragDifference = Vector2.zero;
				}
				return dragDifference;
			case MouseControlMode.Offset:
				dragDifference += new Vector2(Input.mousePosition.x - prevMousePos.x, Input.mousePosition.y - prevMousePos.y);
				prevMousePos = Input.mousePosition;
				return dragDifference;
		}
		return Vector3.zero;
    }

    public override float GetTrigger(Triggers trigger, bool isRaw = false)
    {
        string triggerName = "";
        switch (trigger)
        {
            case Triggers.RightTrigger:
				triggerName = GetButtonName("RightTrigger", "RightTrigger", "RightTrigger");
                break;
            case Triggers.LeftTrigger:
				triggerName = GetButtonName("LeftTrigger", "LeftTrigger", "LeftTrigger");
                break;
        }

        if (Input.GetButton(triggerName))
        {
            return 1f;
        }
        else
        {
            return 0f;
        }
    }

    public override bool GetButton(Buttons button)
    {
		string buttonName = GetButtonHelper(button);
		return Input.GetButton(buttonName);
    }

	public override bool GetButtonDown(Buttons button)
	{
		string buttonName = GetButtonHelper(button);
		return Input.GetButtonDown(buttonName);
	}

    public override bool GetButtonUp(Buttons button)
    {
        return false;
    }

    protected override string GetAxisName(string winID, string linID, string osxID)
    {
        string axisName = "k" + "_Axis_" + winID;

        return axisName;
    }

    protected override string GetButtonName(string winID, string linID, string osxID)
    {
        string buttonName = "k" + "_Button_" + winID;
        return buttonName;
    }

	public override string GetButtonHelper (Buttons button)
	{
		string buttonName = "";

		switch (button)
		{
		case Buttons.RightBumper:
			buttonName = GetButtonName("RB", "RB", "RB");
			break;
		case Buttons.LeftBumper:
			buttonName = GetButtonName("LB", "LB", "LB");
			break;
		case Buttons.A:
			buttonName = GetButtonName("A", "A", "A");
			break;
		case Buttons.B:
			buttonName = GetButtonName("B", "B", "B");
			break;
		case Buttons.X:
			buttonName = GetButtonName("X", "X", "X");
			break;
		case Buttons.Y:
			buttonName = GetButtonName("Y", "Y", "Y");
			break;
		case Buttons.Start:
			buttonName = GetButtonName("Start", "Start", "Start");
			break;
		case Buttons.LeftStickClick:
			buttonName = GetButtonName("LeftStickClick", "LeftStickClick", "LeftStickClick");
			break;
		case Buttons.RightStickClick:
			buttonName = GetButtonName("RightStickClick", "RightStickClick", "RightStickClick");
			break;
		case Buttons.Back:
			buttonName = GetButtonName("Back", "Back", "Back");
			break;
		}

		return buttonName;
	}
}
