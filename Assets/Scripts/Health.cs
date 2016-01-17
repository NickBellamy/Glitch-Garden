using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Health : MonoBehaviour {
	
	public float health = 100f;
	public GameObject healthBar;
	public Color minColor;
	public Color maxColor;
	
	private float maxHealth;
	private Image image;
	
	//TODO: Seperate out the Health Bar components and create a new specific script?
	
	void Start() {
		maxHealth = health;
		if (gameObject.GetComponent<Defenders>()) {
			image = healthBar.GetComponent<Image>();
		}
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
			UpdateHealthBar();
		}
	}
	
	void UpdateHealthBar() {
		//change value
		healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(0.8f * (health / maxHealth), 0f);
		//change color
		image.color = Color.Lerp(minColor,
		                         maxColor,
		                         Mathf.Lerp(0, 1f, health / maxHealth));	
	}
	
	public void DestroyObject() {
		Destroy(gameObject);
	}
}
