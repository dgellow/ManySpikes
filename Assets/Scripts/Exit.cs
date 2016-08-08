using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	public string nextLevel;

	void OnTriggerEnter2D (Collider2D other) {
		Application.LoadLevel (nextLevel);
	}
}
