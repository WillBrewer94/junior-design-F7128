using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarFill : MonoBehaviour {
    public Image bar;
    public float fill;

	// Use this for initialization
	void Start () {
        fill = 1;
	}
	
	// Update is called once per frame
	void Update () {
        HandleFill();
	}

    public void HandleFill() {
        bar.fillAmount = fill;
    }
}
