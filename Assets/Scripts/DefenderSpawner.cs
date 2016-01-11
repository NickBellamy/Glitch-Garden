using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	
	private Camera myCamera;
	private GameObject defendersParent;
	private StarDisplay starDisplay;
	
	void Start(){
		myCamera = GameObject.FindObjectOfType<Camera>();
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		
		//Create "Defenders" GameObject if not found
		defendersParent = GameObject.Find ("Defenders");
		if (defendersParent == null) {
			defendersParent = new GameObject("Defenders");
		}
	}
	
	void OnMouseDown() {
		Vector2 position = CalculateWorldPointOfMouseClick();
		
		GameObject defender = Buttons.selectedDefender;
		int selectedDefenderStarCost = defender.GetComponent<Defenders>().starCost;
		
		if (starDisplay.UseStars(selectedDefenderStarCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender(defender, position);
		} else {
			Debug.Log("Insufficient Stars");
		}
	}
	
	void SpawnDefender(GameObject defender, Vector2 position) {
		Vector2 spawnPoint = CalculateWorldPointOfMouseClick();
		GameObject spawn = Instantiate(defender, spawnPoint, Quaternion.identity) as GameObject;
		//Set spawned defender as a child of the "Defenders" GameObject
		spawn.transform.parent = defendersParent.transform;
	}
	
	Vector2 CalculateWorldPointOfMouseClick() {
		Vector3 clickInWorldUnits = myCamera.ScreenToWorldPoint(Input.mousePosition);
		Vector2 clickInWorldUnitsRounded = new Vector2(Mathf.RoundToInt(clickInWorldUnits.x), Mathf.RoundToInt(clickInWorldUnits.y));
		return clickInWorldUnitsRounded;
	}
}
