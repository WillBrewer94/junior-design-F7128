using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class TouchAnimScript : MonoBehaviour {
    Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if(TouchManager.TouchCount > 0) {
            GetComponent<CanvasRenderer>().SetAlpha(1);
            anim.SetBool("IsTouch", true);
            gameObject.transform.position = TouchManager.GetTouch(0).position;
        } else {
            anim.SetBool("IsTouch", false);
            GetComponent<CanvasRenderer>().SetAlpha(0);
        }
	}
}
