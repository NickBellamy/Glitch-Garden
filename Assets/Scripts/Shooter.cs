using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;
	
	void Start() {
		animator = FindObjectOfType<Animator>();
		
		//If no "Projectiles" GameObject - create one
		projectileParent = GameObject.Find("Projectiles");
		if (projectileParent == null) {
			projectileParent = new GameObject("Projectiles");
		}
		
		SetMyLaneSpawner();
	}
	
	void Update() {
		if (IsAttackerAheadInLane()) {
			animator.SetBool("isAttacking", true);
		} else {
			animator.SetBool("isAttacking", false);
		}
	}
	
	//Look through all spawners and set myLaneSpawner if found
	void SetMyLaneSpawner() {
		float myLane = gameObject.transform.position.y;
		Spawner[] arrayOfSpawners = GameObject.FindObjectsOfType<Spawner>();
		
		foreach (Spawner spawner in arrayOfSpawners) {
			if (spawner.transform.position.y == myLane) {
				myLaneSpawner = spawner;
				return;
			}
		}
		
		Debug.LogError ("Spawner in lane " + myLane.ToString() + " not found!");
		
	}
	
	bool IsAttackerAheadInLane() {
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > gameObject.transform.position.x) {
				return true;
			}
		} 
		return false;
	}

	private void Fire() {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
