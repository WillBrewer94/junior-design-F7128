using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestController : MonoBehaviour {

	public PlayerController player;

	public Image avatarview;
	public Text nameview;
	public Text roleview;



	public Transform t1;
	public Transform t33;
	public Transform t333;

	// Use this for initialization
	void Start () {
		nameview.text = player.name;
		avatarview.sprite = player.avatar;
		roleview.text = player.role;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateQuest () {
		//nothing
	}

	public void tempup() {
		t1.gameObject.SetActive (false);
		t333.gameObject.SetActive (true);
	}
}
