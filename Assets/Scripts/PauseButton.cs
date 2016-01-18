using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseButton : MonoBehaviour {
	
	private LevelManager levelManager;
	private bool isPaused = false;
	private Text text;
	private GameObject messageCanvas;
	private GameObject pauseCanvas;
	
	void Awake() {
		pauseCanvas = GameObject.Find ("Pause Canvas");
	}
	
	void Start() {
		text = gameObject.GetComponent<Text>();
		messageCanvas = GameObject.Find("Level Messages");
		pauseCanvas.SetActive(false);
	}
	
	
	void OnMouseDown() {
		if (isPaused) {
			Time.timeScale = 1.0f;
			text.text = "Pause >";
			messageCanvas.transform.position -= new Vector3 (1000.0f, 1000.0f, 0.0f);
		} else {
			Time.timeScale = 0.0f;
			text.text = "Play >";
			messageCanvas.transform.position += new Vector3 (1000.0f, 1000.0f, 0.0f);
		}
		AudioListener.pause = !AudioListener.pause;
		isPaused = !isPaused;
		pauseCanvas.SetActive(isPaused);
	}
}
