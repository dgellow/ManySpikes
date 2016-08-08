using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour {

	public float maxSpeed = 10f;
	public float lowJumpVelocity = 250;
	public float highJumpVelocity = 500;
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
			var newVelocity = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y);
			if (Input.GetButtonDown ("LowJump")) {
				grounded = false;
				newVelocity.y = lowJumpVelocity;
				rigidbody2D.velocity = newVelocity;
			} else if (Input.GetButtonDown ("HighJump")) {
				grounded = false;
				newVelocity.y = highJumpVelocity;
				rigidbody2D.velocity = newVelocity;
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
