using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    public static InventoryController instance = null;

	public Image avatarview;
	public Text nameview;
	public Text roleview;
	public Text levelview;
	public Text itemsview;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start () {
		nameview.text = PlayerController.instance.name;
		roleview.text = PlayerController.instance.role;
		avatarview.sprite = PlayerController.instance.avatar;
		levelview.text = "Level " + PlayerController.instance.level;
		updateInventory();
		updateLevel();
	}

	void Update () {
		//Add any constantly updating inventory UI items
	}

	// Update items in UI
	public void updateInventory() {
		itemsview.text = "";
		foreach (KeyValuePair<string, int> item in PlayerController.instance.items) {
			itemsview.text += item.Value.ToString () + "x            " + item.Key.ToString () + "\n\n";
		}
	}

	// Update level in UI
	public void updateLevel () {
		levelview.text = "Level " + PlayerController.instance.level;
	}

}
