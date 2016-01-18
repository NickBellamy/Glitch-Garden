using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	private GameObject spawner;
	private GameObject defenders;
	private GameObject projectiles;
	private BoxCollider2D playArea;
	private AudioSource audioSource;
	private AudioSource music;
	private bool debugMode = false;
	private LevelManager levelManager;

	
	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
		spawner = GameObject.Find("Spawners");
		defenders = GameObject.Find ("Defenders");
		playArea = GameObject.FindObjectOfType<DefenderSpawner>().GetComponent<BoxCollider2D>();
		audioSource = GetComponent<AudioSource>();
		if (GameObject.FindObjectOfType<MusicManager>()) {
			music = GameObject.FindObjectOfType<MusicManager>().GetComponent<AudioSource>();
		} else {
			Debug.LogWarning("No music manager found, entering debug mode");
			debugMode = true;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		gameObject.audio.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	public void triggerGameOver() {
		projectiles = GameObject.Find("Projectiles");
		Destroy(defenders);
		Destroy (playArea);
		spawner.transform.position += new Vector3 (1000.0f, 0, 0);
		Invoke ("DestroySpawner", 0.5f);
		Destroy(projectiles);
		gameObject.SetActive(true);
		gameObject.GetComponent<Animator>().SetTrigger("gameOver trigger");
		if (!debugMode) {music.Stop();}
		gameObject.audio.Play();
		Invoke ("LoadLoseLevel", audioSource.clip.length);
	}
	
	void LoadLoseLevel() {
		
		levelManager.LoadLevel("03b Lose");
	}
	
	void DestroySpawner() {
		Destroy(spawner);
	}
}
