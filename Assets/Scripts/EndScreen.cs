using UnityEngine;
using System.Collections;

public class EndScreen: MonoBehaviour {

	public string nextScene;

	void Update () {
		if (Input.anyKeyDown) {
			GameController.gameState.Reset ();
			Application.LoadLevel (nextScene);
		}
	}
}
