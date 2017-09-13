using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImg : MonoBehaviour {
 
	public Image inv;
	public Image main;
	public Image alert;
	public Image header;
	public Image tempscreen; //temporary



	// Use this for initialization
	void Start () {
		Debug.Log ("fdsa");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick(string button) {
		Debug.Log ("WHOA");
		if (button == "inv") {
			inv.sprite = Resources.Load<Sprite> ("Images/b_invent_down") as Sprite;
			main.sprite = Resources.Load<Sprite> ("Images/b_home") as Sprite;
			tempscreen.sprite = Resources.Load<Sprite> ("Images/Home_02") as Sprite;
			header.sprite = Resources.Load<Sprite> ("h_character") as Sprite;
		}
		if (button == "main") {
			inv.sprite = Resources.Load<Sprite> ("Images/b_invent") as Sprite;
			main.sprite = Resources.Load<Sprite> ("Images/b_home_down") as Sprite;
			tempscreen.sprite = Resources.Load<Sprite> ("Images/slices2_02") as Sprite;
			header.sprite = Resources.Load<Sprite> ("h_location") as Sprite;
		}
	}
}
