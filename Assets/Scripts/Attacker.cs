using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;

	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;
	
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		//check if there is no current target, or current target is off screen
		//need to put in this check because of the way destroy works in the health script
		if (!currentTarget || currentTarget.transform.position.x >= 1000000.0f) {
			animator.SetBool("isAttacking", false);
		}
	}
	
	//Needs to be a function - called from the animator
	public void SetSpeed (float speed) {
		currentSpeed = speed;
	}
	
	//Called from the animator at the time of actual attack
	public void StrikeCurrentTarget(float damage) {
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage(damage);
			}
		}
	}
	
	public void Attack (GameObject obj) {
		currentTarget = obj;
	}
	
}
