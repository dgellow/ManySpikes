using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

	public string nextLevel;

	void OnTriggerEnter2D (Collider2D other) {
		SceneManager.LoadScene (nextLevel);
	}
}
