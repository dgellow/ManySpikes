using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerLight : MonoBehaviour {

	public Light light;
	public bool stateOnEnter;
	public bool stateOnExit;
	private BoxCollider2D collider;

	// Use this for initialization
	void Start () {
		if (light == null) {
			throw new MissingReferenceException ("Missing light prefab");
		}
		collider = GetComponent<BoxCollider2D> ();
		collider.isTrigger = true;
	}
	
	void OnTriggerEnter2D() {
		light.enabled = stateOnEnter;
	}

	void OnTriggerExit2D() {
		light.enabled = stateOnExit;
	}
}
