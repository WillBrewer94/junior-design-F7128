using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IphoneTouchWrapper : TouchInputWrapper {

    public IphoneTouchWrapper() {
        Debug.Log("Touch Input Wrapper Instantiated");
    }

    public override bool GetTap() {
        return Input.GetTouch(0).phase == TouchPhase.Ended;
    }

    public override bool GetTouchDown() {
        if(Input.touchCount > 0) {
            return Input.GetTouch(0).phase == TouchPhase.Began;
        }

        return false;
    }

    public override bool GetTouchUp() {
        if(Input.touchCount > 0) {
            return Input.GetTouch(0).phase == TouchPhase.Ended;
        }

        return false;
    }

    public override bool GetSwipe() {
        throw new NotImplementedException();
    }

    public override bool GetSwipeEnd() {
        throw new NotImplementedException();
    }

    public override bool GetSwipeStart() {
        throw new NotImplementedException();
    }
}
