using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Azure.AppServices;

public class UserProfile : DataModel
{

    public string username;
    public string password;
    public string email;

    public UserProfile(string username, string password, string email)
    {
        this.username = username;
        this.password = password;
        this.email = email;
    }

    public UserProfile()
    {
        this.username = "test";
        this.password = "test";
        this.email = "test";
    }
}
