using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour {

	public Transform inventory;

	void Update () {
			//nothing;
	}

	public void SetInventory(bool open) {
		if (open)
			inventory.gameObject.SetActive (true);
		else
			inventory.gameObject.SetActive (false);
	}
	
}
