using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		if (musicManager) {
			float volume = PlayerPrefsManager.GetMasterVolume();
			if (volume != null) {
				musicManager.SetVolume(volume);
			} else {
				musicManager.SetVolume(PlayerPrefsManager.defaultVolume);
			}
		} else {
			Debug.LogWarning ("No music manager found in scene, cannot set volume");
		}
	}
}
