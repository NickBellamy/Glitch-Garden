using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	
	public float levelTime = 100f;
	
	private bool levelComplete = false;
	private Slider slider;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private GameObject youWinLabel;
	private GameObject spawner;
	private GameObject defenders;
	private GameObject projectiles;
	private AudioSource music;
	private float currentMusicVolume;
	private bool debugMode = false;
	private BoxCollider2D playArea;
	
	
	void Start() {
		//TODO find alternatives to "Find"
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		youWinLabel = GameObject.Find ("Level Complete");
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		spawner = GameObject.Find("Spawners");
		defenders = GameObject.Find ("Defenders");
		playArea = GameObject.FindObjectOfType<DefenderSpawner>().GetComponent<BoxCollider2D>();
		if (GameObject.FindObjectOfType<MusicManager>()) {
			music = GameObject.FindObjectOfType<MusicManager>().GetComponent<AudioSource>();
		} else {
			Debug.LogWarning("No music manager found, entering debug mode");
			debugMode = true;
		}
		currentMusicVolume = PlayerPrefsManager.GetMasterVolume();
		
		youWinLabel.SetActive(false);
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update () {
		slider.value += Time.deltaTime / levelTime;
		
		if(slider.value >= slider.maxValue && !levelComplete) {
			projectiles = GameObject.Find("Projectiles");
			levelComplete = true;
			if (!debugMode) {music.volume = (currentMusicVolume * 0.4f);}
			audioSource.audio.Play();
			youWinLabel.SetActive(true);
			Destroy(defenders);
			Destroy (playArea);
			Destroy(spawner);
			Destroy(projectiles);
			Invoke ("LoadNextLevel", audioSource.clip.length + 0.5f);
		}
	}
	
	void LoadNextLevel () {
		if (!debugMode) {music.volume = currentMusicVolume;}
		levelManager.LoadNextLevel();
	}
}