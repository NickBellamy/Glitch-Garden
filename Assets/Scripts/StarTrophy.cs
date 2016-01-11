using UnityEngine;
using System.Collections;

public class StarTrophy : MonoBehaviour {

	public GameObject burstPrefab;
	public GameObject star;
	
	private GameObject starBurst;

	public void StarBurst() {
	Debug.Log ("Burst called");
		Vector3 starPos = star.transform.position;
		starPos.z = burstPrefab.GetComponent<Transform>().position.z;
		starBurst = Instantiate(burstPrefab, starPos, Quaternion.identity) as GameObject;
		starBurst.transform.parent = gameObject.transform;
	}
}
