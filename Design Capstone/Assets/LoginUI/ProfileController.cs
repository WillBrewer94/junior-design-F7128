﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileController : MonoBehaviour
{

    public static ProfileController instance = null;

    public string name;
    public string role;
    public int level;
    public Sprite avatar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            name = "test";
            role = "test";
            level = 0;
            avatar = null;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}