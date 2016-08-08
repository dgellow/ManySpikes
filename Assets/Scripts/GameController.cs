using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController gameState;

	[SerializeField]
	private int defaultLives = 10;
	[SerializeField]
	private int currentLives = 1;

	void Awake () {
		if (gameState == null) {
			DontDestroyOnLoad (gameObject);
			gameState = this;
			currentLives = defaultLives;
		} else if (gameState != this) {
			Reset ();
		}
	}

	void OnGUI() {
		GUI.Label (new Rect(10, 10, 100, 30), "Lives: " + currentLives);
	}

	public void KillCharacter() {
		currentLives -= 1;

		if (currentLives > 0) {
			Application.LoadLevel (Application.loadedLevel);
		} else {
			currentLives = 0;
			Application.LoadLevel ("Game Over");
		}
	}

	public void Reset() {
		Destroy (gameObject);
	}
}
