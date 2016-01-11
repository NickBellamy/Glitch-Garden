using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	private Animator animator;
	
	void Start() {
		animator = GetComponent<Animator>();
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.GetComponent<Attacker>()) {
			animator.SetTrigger("underAttack trigger");
		}
	}
}
