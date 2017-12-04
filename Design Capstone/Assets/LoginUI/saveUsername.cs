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

public class saveUsername : MonoBehaviour {

    public InputField inputName;

    public InputField inputEmail;

    public InputField inputPass;

    public string savedName;
    public string savedEmail;
    public string savedPass;

    public Button SubmitButton;
    public Button BackButton;

    private string _appUrl = "http://buzzgameapp.azurewebsites.net";
    private AppServiceClient _client;
    private AppServiceTable<UserProfile> _table;
    private UserProfile _user;
 

    // Use this for initialization
    void Start () {
        inputName.onEndEdit.AddListener(delegate { saveAll(); });
        inputEmail.onEndEdit.AddListener(delegate { saveAll(); });
        inputPass.onEndEdit.AddListener(delegate { saveAll(); });

        _client = new AppServiceClient(_appUrl);

        _table = _client.GetTable<UserProfile>("Users");

        savedName = "Blank";
        savedEmail = "Blank";
        savedPass = "Blank";

        Button btn = SubmitButton.GetComponent<Button>();
        Button btn2 = BackButton.GetComponent<Button>();
        btn2.onClick.AddListener(IntroLoad);
        btn.onClick.AddListener(saveAll);
    }

    void UsernameSave(InputField input)
    {
        if (input.text.Length > 0)
        {
            savedName = input.text;
        }
    }

    void EmailSave(InputField input)
    {
        if (input.text.Length > 0)
        {
            savedEmail = input.text;
        }
    }

    void PasswordSave(InputField input)
    {
        if (input.text.Length > 0)
        {
            savedPass = input.text;
        }
    }

    void saveAll()
    {
        if (inputName.text.Length > 0 && inputEmail.text.Length > 0 && inputPass.text.Length > 0)
        {
            savedName = inputName.text;
            savedEmail = inputEmail.text;
            savedPass = inputPass.text;
            createPlayer(savedName, savedPass, savedEmail);
        }
    }
 
     void LoginPlayer()
     {
 
     }
 
     public void createPlayer(String name, String pass, String email)
     {
         UserProfile testBoi = new UserProfile(name, pass, email);
         StartCoroutine(_table.Insert<UserProfile>(testBoi, OnInsertCompleted));
         ProfileController.instance.name = savedName;
         ProfileController.instance.role = "test";
         ProfileController.instance.level = 1;
         ProfileController.instance.avatar = null;
 
         SceneManager.LoadScene("MainScene");
     }
 
     private void OnInsertCompleted(IRestResponse<UserProfile> response)
     {
         if (!response.IsError && response.StatusCode == HttpStatusCode.Created)
         {
             Debug.Log("OnInsertItemCompleted: " + response.Content + " status code:" + response.StatusCode + " data:" + response.Data);
             UserProfile item = response.Data; // if successful the item will have an 'id' property value
             _user = item;
         }
         else
         {
             Debug.LogWarning("Insert Error Status:" + response.StatusCode + " Url: " + response.Url);
        }
    }

    void IntroLoad()
    {
        SceneManager.LoadScene("Intro_Scene");
    }

}
