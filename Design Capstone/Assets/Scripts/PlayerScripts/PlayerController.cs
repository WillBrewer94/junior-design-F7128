using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public string name;
	public string role;
	public int level;
	public Sprite avatar;
	public Dictionary<string, int> items;

	public InventoryController invcon;


	void Start() {
		// temporary item list
		items = new Dictionary<string, int>();
		Item i1 = new Item ("Potion of Health", "Heal");
		Item i2 = new Item ("Staff of Seniority", "Time");
		Item i3 = new Item ("Rat Cap", "Swag");

		items.Add ("Potion of Health", 4);
		items.Add ("Staff of Seniority", 3);
		items.Add ("Rat Cap", 1);
		items.Add ("Monster Bait", 1);
		items.Add ("Escape Rope", 2);
		items.Add ("Telescope", 1);
		items.Add ("Overload Application", 3);

		invcon.updateInventory();
	}
}
