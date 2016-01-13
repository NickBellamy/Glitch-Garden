using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private GameOver gameOver;

	
	void Awake() {
		gameOver = GameObject.FindObjectOfType<GameOver>();
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.GetComponent<Attacker>()) {
		gameOver.triggerGameOver();

		}
	}
	

}
