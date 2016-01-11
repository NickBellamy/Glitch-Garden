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
	
	
	void Start() {
		//TODO find alternatives to "Find"
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		youWinLabel = GameObject.Find ("Level Complete");
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		spawner = GameObject.Find("Spawners");
		defenders = GameObject.Find ("Defenders");
		
		youWinLabel.SetActive(false);
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update () {
		slider.value += Time.deltaTime / levelTime;
		
		if(slider.value >= slider.maxValue && !levelComplete) {
			levelComplete = true;
			audioSource.audio.Play();
			youWinLabel.SetActive(true);
			Destroy(defenders);
			Destroy(spawner);
			Invoke ("LoadNextLevel", audioSource.clip.length + 0.5f);
		}
	}
	
	void LoadNextLevel () {
		levelManager.LoadNextLevel();
	}
}
