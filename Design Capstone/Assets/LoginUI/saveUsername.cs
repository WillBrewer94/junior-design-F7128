using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveUsername : MonoBehaviour {

    public Text DisplayText;

    public InputField inputName;
    public Text textName;

    public InputField inputEmail;
    public Text textEmail;

    public InputField inputPass;
    public Text textPass;

    public Button SubmitButton;
    public Button BackButton;

    public string savedName;
    public string savedEmail;
    public string savedPass;
    

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
	
	// Update is called once per frame
	void Update () {
        if (savedName != null)
        {
            DisplayText.text = savedName;
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

    void IntroLoad()
    {
        SceneManager.LoadScene("Intro_Scene");
    }

}
