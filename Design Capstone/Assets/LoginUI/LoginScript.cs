using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Azure.AppServices;
using System;
using System.Net;
using RESTClient;
using System.Linq;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour {

    public InputField EmailField;

    public InputField PassField;

    public string savedEmail;
    public string savedPass;

    public Button SubmitButton;
    public Button BackButton;

    private string _appUrl = "http://buzzgameapp.azurewebsites.net";
    private AppServiceClient _client;
    private AppServiceTable<UserProfile> _table;
    private List<UserProfile> _users = new List<UserProfile>();
    private List<UserProfile> users = new List<UserProfile>();

    // Use this for initialization
    void Start () {
        EmailField.onEndEdit.AddListener(delegate { tryLogin(); });
        PassField.onEndEdit.AddListener(delegate { tryLogin(); });

        _client = new AppServiceClient(_appUrl);

        _table = _client.GetTable<UserProfile>("Users");

        savedEmail = "Blank";
        savedPass = "Blank";

        Button btn = SubmitButton.GetComponent<Button>();
        Button btn2 = BackButton.GetComponent<Button>();
        btn2.onClick.AddListener(IntroLoad);
        btn.onClick.AddListener(tryLogin);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("enter"))
        {
            tryLogin();
        } 
    }

    private void tryLogin()
    {
        if (EmailField.text.Length > 0 && PassField.text.Length > 0)
        {
            savedEmail = EmailField.text;
            savedPass = PassField.text;
            GetUsers();
        }
    }

    private void OnReadNestedResultsCompleted(IRestResponse<NestedResults<UserProfile>> response)
    {
        if (!response.IsError)
        {
            Debug.Log("OnReadNestedResultsCompleted: " + response.Url + " data: " + response.Content);
            UserProfile[] items = response.Data.results;
            _users.AddRange(items.ToList());
            UserProfile target = _users.Find(x => String.Equals(x.email, savedEmail));
            if (target != null)
            {
                if (target.password == (savedPass))
                {
                    Debug.Log("You got it");
                    ProfileController.instance.name = target.username;
                    ProfileController.instance.role = "test";
                    ProfileController.instance.level = 1;
                    ProfileController.instance.avatar = null;

                    SceneManager.LoadScene("MainScene");
                }
                else
                {
                    Debug.Log("We got nothing");
                }
            }
            else
            {
                Debug.Log("Invalid Username");
            }
        }
        else
        {
            Debug.LogWarning("Read Nested Results Error Status:" + response.StatusCode.ToString() + " Url: " + response.Url);
        }
    }

    private void GetUsers()
    {
        _users.Clear();
        var orderBy = new OrderBy("id", SortDirection.desc);
        TableQuery query = new TableQuery("", 0, 0, "id,email,username,password", TableSystemProperty.nil, false, orderBy);
        StartCoroutine(_table.Query<UserProfile>(query, OnReadNestedResultsCompleted));
    }

    void IntroLoad()
    {
        SceneManager.LoadScene("Intro_Scene");
    }
}
