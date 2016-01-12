using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] spawnObjects;
	
	void Update() {
		foreach(GameObject thisAttacker in spawnObjects) {
			if (IsTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
		
	}
	
	void Spawn (GameObject myGameObject) {
			Vector3 spawnPosition = gameObject.transform.position;
			GameObject newEnemy = Instantiate (myGameObject, spawnPosition, Quaternion.identity) as GameObject;
			newEnemy.transform.parent = gameObject.transform;
		}
	
	bool IsTimeToSpawn (GameObject attacker) {
		float frequency = attacker.GetComponent<Attacker>().seenEverySeconds;
		float diffAdjustedFreq = frequency * (1 - (PlayerPrefsManager.GetDifficulty() * 0.33f));
		float threshold = Time.deltaTime / diffAdjustedFreq;
		
		if (threshold > 1) {
			Debug.LogWarning("Spawn rate exceeds frame-rate!  Capping spawn rate to frame-rate.");
			threshold = 1;			
		}
		//Divide threshold by number of lanes to make seenEverySeconds correct over all Spawners
		threshold /= 5f;
		return (Random.value < threshold);
		
	}
}
