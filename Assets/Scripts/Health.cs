using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public float health = 100f;
	public GameObject healthBar;
	
	private float maxHealth;
	
	void Start() {
		maxHealth = health;
	}
	
	public void DealDamage(float damage) {
		health -= damage;
		if (health <= 0) {
			//Move position of object with zero health and then wait to destroy it
			//This ensures that the OnTriggerExit2D function gets called which is
			//used to keep track of the rustling sound from the hedges.
			gameObject.transform.position += new Vector3(1000000.0f, 1000000.0f, 0.0f);
			Invoke ("DestroyObject", 2.0f);
		}
		if (gameObject.GetComponent<Defenders>()) {
			healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(health / maxHealth, 0f);
		}
	}
	
	public void DestroyObject() {
		Destroy(gameObject);
	}
}
