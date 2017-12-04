using System;
using UnityEngine;
using Azure.AppServices;

[Serializable]
public class UserProfile : DataModel
{

    public string username;
    public string password;
    public string email;
    public string role;
    public int level;
    public string avatar;

    public UserProfile(string username, string password, string email, string role, int level, string avatar)
    {
        this.username = username;
        this.password = password;
        this.email = email;
        this.role = role;
        this.level = level;
        this.avatar = avatar;
    }

    public UserProfile(string username, string password, string email)
    {
        this.username = username;
        this.password = password;
        this.email = email;
        this.role = "test";
        this.level = 1;
        this.avatar = "test";
    }

    public UserProfile()
    {
        this.username = "test";
        this.password = "test";
        this.email = "test";
        this.role = "test";
        this.level = 1;
        this.avatar = "test";
    }
}
