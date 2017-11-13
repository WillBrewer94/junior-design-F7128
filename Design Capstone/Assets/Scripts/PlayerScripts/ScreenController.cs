using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour {

	public Transform inventory;
	public Transform quest;

	void Update () {
			//nothing;
	}

	public void SetInventory(bool open) {
		if (open)
			inventory.gameObject.SetActive (true);
		else
			inventory.gameObject.SetActive (false);
	}

	public void SetQuest(bool open) {
		if (open)
			quest.gameObject.SetActive (true);
		else
			quest.gameObject.SetActive (false);
	}
}
