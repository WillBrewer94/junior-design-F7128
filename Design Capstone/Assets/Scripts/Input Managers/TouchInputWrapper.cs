using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TouchInputWrapper.cs
// Abstract class that all touch input wrappers will extend from. 
// Includes the base methods that children will override.

public abstract class TouchInputWrapper {
    public enum Gyroscope { };
    public enum Buttons { Home, VolUp, VolDown };
    //public enum Touch { Screen };

    // Abstract methods representing certain touch inputs

    // A tap is a verified touch-and-release, used
    // for selecting specific items
    public abstract bool GetTap();

    // GetTouchDown and GetTouchUp can be used to track starting 
    // and ending locations
    public abstract bool GetTouchDown();

    public abstract bool GetTouchUp();

    // The difference between moving while touching and swiping
    // will be determined by a velocity threshold
    public abstract bool GetSwipe();

    //TODO:
    public abstract bool GetSwipeStart();

    //TODO:
    public abstract bool GetSwipeEnd();

    protected int devNum;

    public TouchInputWrapper() {
      
    }

    public override bool Equals(object other) {
        // Null check
        if(other == null) {
            return false;
        }

        // Casts the object as TouchInputWrapper then null tests
        TouchInputWrapper test = other as TouchInputWrapper;
        if((System.Object)test == null) {
            return false;
        }

        return false;
    }

    // Returns hashcode (id) of this object
    public override int GetHashCode() {
        return base.GetHashCode();
    }
}
