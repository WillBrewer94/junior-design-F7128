using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

	public PlayerController player;

	public Image avatarview;
	public Text nameview;
	public Text roleview;
	public Text levelview;

	public Text itemsview;

	private bool update;


	void Start () {
		nameview.text = player.name;
		roleview.text = player.role;
		avatarview.sprite = player.avatar;
		levelview.text = "Level " + player.level;

		update = true;
	}

	void Update () {
		levelview.text = "Level " + player.level;
		if (update) {
			itemsview.text = "";
			foreach (KeyValuePair<string, int> item in player.items) {
				itemsview.text += item.Value.ToString () + "x            " + item.Key.ToString () + "\n\n";
			}
			update = false;
		}
	}
}
