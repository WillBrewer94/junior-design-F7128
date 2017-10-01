using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveUsername : MonoBehaviour {

    public InputField inputName;
    public Text textName;

    public InputField inputEmail;
    public Text textEmail;

    public InputField inputPass;
    public Text textPass;

    public string savedName;
    public string savedEmail;
    public string savedPass;
    

    // Use this for initialization
    void Start () {
        inputName.onEndEdit.AddListener(delegate { saveAll(); });
        inputEmail.onEndEdit.AddListener(delegate { saveAll(); });
        inputPass.onEndEdit.AddListener(delegate { saveAll(); });
    }
	
	// Update is called once per frame
	void Update () {
        if (savedName != null)
        {
            textName.text = savedName;
        }
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
            savedName = inputEmail.text;
        }
    }

}
