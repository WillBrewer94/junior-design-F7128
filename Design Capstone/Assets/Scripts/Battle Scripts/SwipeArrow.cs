using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeArrow : MonoBehaviour {
    public float speed;
    public static Object prefab;

	// Use this for initialization
	void Start () {
        prefab = Resources.Load("Prefabs/SwipeArrow");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(0, -(speed * Time.deltaTime)));
	}

    //Allows the creation of a prefab with specific parameters
    //Overload as needed
    public static GameObject Create() {
        GameObject newArrow = Instantiate(prefab) as GameObject;
        return newArrow;
    }
}
