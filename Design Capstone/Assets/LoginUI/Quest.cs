using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Azure.AppServices;

public class Quest : DataModel
{

    public string difficulty;
    public string reward;
    public string description;

    public Quest(string difficulty, string reward, string description)
    {
        this.difficulty = difficulty;
        this.reward = reward;
        this.description = description;
    }

    public Quest()
    {
        this.difficulty = "test";
        this.reward = "test";
        this.description = "test";
    }
}
