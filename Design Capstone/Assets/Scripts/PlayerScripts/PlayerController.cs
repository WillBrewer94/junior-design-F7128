using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public string name;
	public string role;
	public int level;
	public Sprite avatar;
	public Dictionary<string, int> items;  // represents item name (string) and its count (int)
	public Dictionary<string, int> quests;  //represents quest name (string) and its progress (int)

	public InventoryController invcon;
	public QuestController quecon;

	void Start() {
		items = new Dictionary<string, int>();
		quests = new Dictionary<string, int>();

		/*Item i1 = new Item ("Potion of Health", "Heal");
		Item i2 = new Item ("Staff of Seniority", "Time");
		Item i3 = new Item ("Rat Cap", "Swag");*/
		items.Add ("Potion of Health", 4);
		items.Add ("Staff of Seniority", 3);
		items.Add ("Rat Cap", 1);
		items.Add ("Monster Bait", 1);
		items.Add ("Escape Rope", 2);
		items.Add ("Telescope", 1);
		items.Add ("Overload Application", 3);
		items.Add ("T1", 10);
		items.Add ("T2", 32);
		items.Add ("T3", 40);


		quests.Add("D1",40);
		quests.Add("D2",0);


		invcon.updateInventory();
		quecon.updateQuest();
	}

	public void addItem(string[] id) {
		for (int i = 0; i < id.Length; i++) {
			if (items.ContainsKey(id[i]))
				items [id [i]]++;
			else
				items.Add(id[i], 1);
		}
		invcon.updateInventory();
	}

	public void removeItem(string[] id) {
		for (int i = 0; i < id.Length; i++) {
			if (items.ContainsKey(id[i])) {
				items[id[i]]--;
				if (items[id[i]] < 1) items.Remove(id [i]);
			}
		}
		invcon.updateInventory();
	}


	public void addQuest(string[] id) {
		for (int i = 0; i < id.Length; i++) {
				quests.Add(id[i], 0);
		}
		quecon.updateQuest();
	}

	public void updateQuest(string id, int progress) {
		if (quests.ContainsKey (id)) {
			quests [id] += progress;
			if (quests [id] >= 100) quests.Remove (id);
		}
		quecon.updateQuest();
	}





	public void tempAdd() {
		addItem (new string[] {"Rat Cap","Monster Bait","Escape Rope","Potion of Health","Potion of Health","Potion of Health","Potion of Health","Potion of Health","Potion of Health",});
	}

	public void tempRemove() {
		removeItem (new string[] {"Rat Cap","Monster Bait","Monster Bait","Escape Rope","Potion of Health","Potion of Health",});
	}


	public void tempQQ() {
		addQuest (new string[]  { "" });
		addQuest (new string[]  { "" });
	}

	public void tempQQQQ() {
		updateQuest ("", 25);
		updateQuest ("", 34);
		updateQuest ("", 100);
	}
}
