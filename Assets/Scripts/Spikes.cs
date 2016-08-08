using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	public bool animated = false;
	public Vector2 directions;
	public AnimationCurve curve;

	private Vector3 origin;
	private float timer;
	

	// Use this for initialization
	void Start () {
		origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (animated) {
			timer += Time.deltaTime;
			var value = curve.Evaluate (timer);
			var newPosition = new Vector3 (origin.x + (value * directions.x), origin.y + (value * directions.y), origin.z);
			transform.position = newPosition;
		}
	}
}
