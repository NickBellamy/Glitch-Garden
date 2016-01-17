using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bush : MonoBehaviour {
	
	private Animator animator;
	private AudioSource rustle;
	//Use this to keep track of how many Attackers are in the bush
	private List <GameObject> currentCollisions = new List <GameObject>();
	
	void Start() {
		animator = GetComponent<Animator>();
		rustle = GetComponent<AudioSource>();
		//Multiply volume by 0.8 as it doesn't need to be quite as loud as the music
		rustle.volume = PlayerPrefsManager.GetMasterVolume() * 0.8f;
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.GetComponent<Attacker>()) {
			currentCollisions.Add (col.gameObject);
		}
	}
	
	//Play sound when attacker is in bush
	void OnTriggerStay2D(Collider2D col) {
		if (col.GetComponent<Attacker>()) {
			animator.SetTrigger("rustle trigger");
			if(!rustle.isPlaying) {
				rustle.Play();
			}
		}
		
	}
	
	//Stop sound if number of attackers in the bush is zero
	void OnTriggerExit2D(Collider2D col) {
		if (col.GetComponent<Attacker>()) {
			currentCollisions.Remove(col.gameObject);
			if (currentCollisions.Count == 0) {
				rustle.Stop();
			}
		}
	}
}