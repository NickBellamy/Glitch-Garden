using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Buttons : MonoBehaviour {
	
	public static GameObject selectedDefender;
	public GameObject prefab;
	
	private SpriteRenderer spriteRenderer;
	private Buttons[] selectButtons;
	private Text costText;
	
	void Start() {
		selectButtons = GameObject.FindObjectsOfType<Buttons>();
		costText = GetComponentInChildren<Text>();
		
		if (costText) {
			costText.text = prefab.GetComponent<Defenders>().starCost.ToString();
		} else {
			Debug.LogWarning ("starCost not found for " + name);
		}
	}
	
	void OnMouseDown() {
		foreach(Buttons selectButton in selectButtons) {
			selectButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.color = Color.white;
		selectedDefender = prefab;
	}
}