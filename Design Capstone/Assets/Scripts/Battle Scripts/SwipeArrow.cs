﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeArrow : MonoBehaviour {
    public float speed;
    public string swipeType;

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));
    }
}
