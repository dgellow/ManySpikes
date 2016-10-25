using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndScreen: MonoBehaviour {

	public string nextScene;

	void Update () {
		if (Input.anyKeyDown) {
			GameController.gameState.Reset ();
			SceneManager.LoadScene (nextScene);
		}
	}
}
