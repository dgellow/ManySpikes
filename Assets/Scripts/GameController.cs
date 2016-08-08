using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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

	public void Save() {
		var data = new PlayerData ();
		data.currentLives = currentLives;

		var formatter = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.OpenOrCreate);
		formatter.Serialize (file, data);
		file.Close ();
	}

	public void Load() {
		var filename = Application.persistentDataPath + "/playerInfo.dat";
		if (File.Exists (filename)) {
			var formatter = new BinaryFormatter ();
			var file = File.Open (filename, FileMode.Open);
			var data = formatter.Deserialize (file) as PlayerData;	
			file.Close ();

			currentLives = data.currentLives;
		}
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

[Serializable]
class PlayerData {
	public int currentLives;
}