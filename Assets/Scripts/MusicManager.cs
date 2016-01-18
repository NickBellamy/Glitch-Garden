using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject); 
	}
	
	void Start() {
		audioSource = GetComponent<AudioSource>();
		float volume = PlayerPrefsManager.GetMasterVolume();
		if (volume != null) {
			SetVolume(volume);
		} else {
			SetVolume(PlayerPrefsManager.defaultVolume);
		}
	}
	
	void OnLevelWasLoaded(int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		if (thisLevelMusic == audioSource.clip) {
			Debug.Log ("Same Level Music");
		}
				
		if (thisLevelMusic && thisLevelMusic != audioSource.clip) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}
	
	public void SetVolume ( float volume) {
		audioSource.volume = volume;
	}
}
