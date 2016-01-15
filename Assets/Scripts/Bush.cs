using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bush : MonoBehaviour {
	
	private Animator animator;
	private AudioSource rustle;
	private List <GameObject> currentCollisions = new List <GameObject>();
	
	void Start() {
		animator = GetComponent<Animator>();
		rustle = GetComponent<AudioSource>();
		rustle.volume = PlayerPrefsManager.GetMasterVolume() * 0.8f;
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.GetComponent<Attacker>()) {
			currentCollisions.Add (col.gameObject);
		}
	}
	
	void OnTriggerStay2D(Collider2D col) {
		if (col.GetComponent<Attacker>()) {
			animator.SetTrigger("rustle trigger");
			if(!rustle.isPlaying) {
				rustle.Play();
			}
		}
		
	}
	
	void OnTriggerExit2D(Collider2D col) {
		if (col.GetComponent<Attacker>()) {
			currentCollisions.Remove(col.gameObject);
			if (currentCollisions.Count == 0) {
				rustle.Stop();
			}
		}
	}
}