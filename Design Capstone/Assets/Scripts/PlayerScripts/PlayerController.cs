using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance = null;

	public string name;
	public string role;
	public int level;
	public Sprite avatar;
	public Dictionary<string, int> items;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start() {
        name = ProfileController.instance.name;
        role = ProfileController.instance.role;
        level = ProfileController.instance.level;
        avatar = ProfileController.instance.avatar;

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

		InventoryController.instance.updateInventory();
	}
}
