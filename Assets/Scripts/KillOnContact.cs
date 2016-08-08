using UnityEngine;
using System.Collections;

public class KillOnContact : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other) {
		KillCharacter (other.gameObject.GetComponent<CharacterController2D> ());
	}

	void OnTriggerEnter2D (Collider2D other) {
		KillCharacter (other.GetComponent<CharacterController2D> ());
	}

	void KillCharacter (CharacterController2D character) {
		if (character != null) {
			GameController.gameState.KillCharacter ();
		}
	}
}
