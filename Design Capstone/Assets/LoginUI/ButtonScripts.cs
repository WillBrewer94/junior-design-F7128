using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {

    public Button LoginButton;
    public Button RegisButton;

    // Use this for initialization
    void Start () {
        Button btn = LoginButton.GetComponent<Button>();
        Button btn2 = RegisButton.GetComponent<Button>();
        btn2.onClick.AddListener(RegistrationLoad);
        btn.onClick.AddListener(LoginLoad);
    }

    void RegistrationLoad()
    {
        SceneManager.LoadScene("RegistrationScene");
    }

    void LoginLoad()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
