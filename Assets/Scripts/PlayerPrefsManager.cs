﻿using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	
	public static float defaultVolume = 0.8f;
	public static float defaultDifficulty = 0;
	
	//Master Volume Set
	
	public static void SetMasterVolume(float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master Volume out of range");
		}
	}
	
	//Master Volume Get
	
	public static float GetMasterVolume() {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY, defaultVolume);
	}
	
	//Difficulty Set
	
	public static void SetDifficulty (float difficulty) {
		if (difficulty >= -1f && difficulty <= 1f) {
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Difficulty out of range");
		}
	}
	
	//Difficulty Get
	
	public static float GetDifficulty() {
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY, defaultDifficulty);
	}
	
	//Level Unlock Set
	
	public static void SetLevelUnlock (int level) {
		if (level <= Application.levelCount -1) {
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //Use 1 for true
		} else {
			Debug.LogError("Level unlock out of range");
		}
	}
	
	//Level Unlock Get
	
	public static bool IsLevelUnlocked (int level) {
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
		
		if (level <= Application.levelCount -1) {
			return isLevelUnlocked;
		} else {
			Debug.Log ("Level not not found");
			return false;
		}
	}
}
