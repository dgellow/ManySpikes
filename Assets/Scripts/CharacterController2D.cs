using UnityEngine;
using System.Collections;

enum Directions {
	Right, Left
}

public class CharacterController2D : MonoBehaviour {

	public float maxSpeed = 10f;
	public float lowJumpForce = 250;
	public float highJumpForce = 500;
	public Transform groundCheck;
	public LayerMask groundLayer;

	private Directions facingDirection = Directions.Right;
	private Rigidbody2D rigidbody2D;
	private Animator anim;
	private bool grounded = false;
	private float groundCheckRadius = 0.2f;

	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		anim.SetBool ("Grounded", grounded);

		var move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		anim.SetFloat ("HorizontalSpeed", Mathf.Abs (move));
		anim.SetFloat ("VerticalSpeed", rigidbody2D.velocity.y);

		if ((move < 0 && facingDirection == Directions.Right) ||
			(move > 0 && facingDirection == Directions.Left)) {
			Flip ();
		}
	}

	void Update () {
		if (grounded) {
			if (Input.GetButton ("Fire2")) {
				grounded = false;
				rigidbody2D.AddForce (new Vector2(0, lowJumpForce));
			} else if (Input.GetButton ("Fire1")) {
				grounded = false;
				rigidbody2D.AddForce (new Vector2(0, highJumpForce));
			}
		}
	}

	void Flip() {
		facingDirection = facingDirection == Directions.Right ? Directions.Left : Directions.Right;
		var newScale = transform.localScale;
		newScale.x *= -1;
		transform.localScale = newScale;
	}
}
