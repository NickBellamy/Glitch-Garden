using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public float fadeInTime;
	
	private Image fadePanel;
	
	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();
		fadePanel.CrossFadeAlpha(0, fadeInTime, false);
	}
	
	void Update() {
		if (Time.timeSinceLevelLoad > fadeInTime) {
			SwitchOffPanel();
		}
	}
	
	void SwitchOffPanel() {
		gameObject.SetActive(false);
	}

}
