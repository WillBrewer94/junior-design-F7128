using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour {

	public Sprite hover;
	public Sprite origin;
	public Image image;

	public void Enter()
	{
		image.sprite = hover; //Or however you do your color
	}

	public void Exit ()
	{
		image.sprite = origin; //Or however you do your color
	}

}