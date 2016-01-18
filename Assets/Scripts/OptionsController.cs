using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;
	public Button defaultsButton;
	public Button applyButton;
	 
	private MusicManager musicManager;
	
	
	// Use this for initialization
	void Start () {
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
		musicManager = GameObject.FindObjectOfType<MusicManager>();	
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.SetVolume(volumeSlider.value);
	}
	
	public void ApplySettings() {
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		levelManager.LoadLevel("01a Start");
	}
	
	public void SetDefaults() {
		volumeSlider.value = PlayerPrefsManager.defaultVolume;
		difficultySlider.value = PlayerPrefsManager.defaultDifficulty;
	}
	
	public void SliderChanged () {
		if (volumeSlider.value != PlayerPrefsManager.defaultVolume || difficultySlider.value != PlayerPrefsManager.defaultDifficulty) {
			defaultsButton.interactable = true;
		} else {
			defaultsButton.interactable = false;
		}
		
		if (volumeSlider.value != PlayerPrefsManager.GetMasterVolume() || difficultySlider.value != PlayerPrefsManager.GetDifficulty()){
			applyButton.interactable = true;
		} else {
			applyButton.interactable = false;
		}
	}
}
