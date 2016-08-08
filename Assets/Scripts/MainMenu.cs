using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

	public EventSystem eventSystem;
	private GameObject selectedItem;

	void Start() {
		selectedItem = eventSystem.firstSelectedGameObject;
	}

	void Update() {
		if (eventSystem.currentSelectedGameObject != selectedItem) {
			if (eventSystem.currentSelectedGameObject == null) {
				eventSystem.SetSelectedGameObject (selectedItem);
			} else {
				selectedItem = eventSystem.currentSelectedGameObject;	
			}
		}
	}

	public void NewGame () {
		Application.LoadLevel ("Level 1-1");	
	}

	public void Exit () {
		Application.Quit ();
	}
}
