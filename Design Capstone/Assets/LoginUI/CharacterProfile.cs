using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Azure.AppServices;

public class CharacterProfile : DataModel
{

    public string location;
    public int level;
    public int exp;

    public CharacterProfile(string location, int level, int exp)
    {
        this.location = location;
        this.level = level;
        this.exp = exp;
    }

    public CharacterProfile()
    {
        this.location = "here";
        this.level = 0;
        this.exp = 0;
    }
}
