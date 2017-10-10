using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    void Update() {
        if(GetTouchDown()) {
            Debug.Log("Touchdown!");
        }
    }

    protected bool GetTap() {
        return TouchInputManager.instance.GetTap();
    }

    protected bool GetTouchDown() {
        return TouchInputManager.instance.GetTouchDown();
    }

    protected bool GetTouchUp() {
        return TouchInputManager.instance.GetTouchUp();
    }
}
