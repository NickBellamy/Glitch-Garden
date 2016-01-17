using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
public class chicken : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
		
	}
	
	public void OnTriggerEnter2D (Collider2D col) {
		GameObject obj = col.gameObject;
		
		if (!obj.GetComponent<Defenders>()) {
			return;
		}
		
		attacker.Attack(obj);
		animator.SetBool("isAttacking", true);
		
	}
}