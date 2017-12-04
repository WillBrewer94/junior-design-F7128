using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour {

	public Transform inventory;
	public Transform quest;

	public ButtonHover inv;
	public ButtonHover home;
	public ButtonHover q;


	void Update () {
			//nothing;
	}

	public void SetInv(){
		SetInventory (true);
		SetQuest (false);
		setHome (false);
	}

	public void SetQ() {
		SetInventory (false);
		SetQuest (true);
		setHome (false);
	}

	public void SetH() {
		SetInventory (false);
		SetQuest (false);
		setHome (true);
	}

	public void SetInventory(bool open) {
		if (open) {
			inventory.gameObject.SetActive (true);
			inv.Enter ();
		} else {
			inventory.gameObject.SetActive (false);
			inv.Exit ();
		}
	}

	public void SetQuest(bool open) {
		if (open) {
			quest.gameObject.SetActive (true);
			q.Enter ();
		} else {
			quest.gameObject.SetActive (false);
			q.Exit ();
		}
	}


	public void setHome(bool open) {
		if (open) {
			home.Enter ();
		} else {
			home.Exit ();
		}
	}

}
