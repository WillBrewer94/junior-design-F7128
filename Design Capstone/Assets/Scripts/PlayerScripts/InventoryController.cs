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


	void Start () {
		nameview.text = player.name;
		roleview.text = player.role;
		avatarview.sprite = player.avatar;
		levelview.text = "Level " + player.level;
		updateLevel();
	}

	void Update () {
		//Add any constantly updating inventory UI items
	}

	// Update items in UI
	public void updateInventory() {
		itemsview.text = "";
		foreach (KeyValuePair<string, int> item in player.items) {
			itemsview.text += item.Value.ToString () + "x            " + item.Key.ToString () + "\n\n";
		}
	}

	// Update level in UI
	public void updateLevel () {
		levelview.text = "Level " + player.level;
	}

}
