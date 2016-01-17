using UnityEngine;
using System.Collections;

public class LevelBegin : MonoBehaviour {

	private AudioSource bell;
		
	void Start() {
		bell = gameObject.GetComponent<AudioSource>();
		bell.volume = PlayerPrefsManager.GetMasterVolume();
	}	

	public void PlaySound() {
		bell.audio.Play();
	}
	
	public void disableLevelBegin() {
		gameObject.SetActive(false);
	}
}
