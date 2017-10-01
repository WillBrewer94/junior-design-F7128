using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public string name;
	public string ability;

	public Item(string name, string ability) {
		this.name = name;
		this.ability = ability;
	}
	public override string ToString() {
		return name;
	}
}