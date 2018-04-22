using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	Transform _camera;
	[HideInInspector] public Rigidbody2D m_rigidbody2D;
	[SerializeField] public bool grounded = true;
	[SerializeField] float jumpForce = 10;
	[SerializeField] float jetpagForce = 1;
	[SerializeField] float jetpagTime = 5;
	float jetpagTimer = 0;
	bool jetpagLanded = true;
	[SerializeField] float moveSpeed = 5;
	[SerializeField] GameObject fire;
	// Use this for initialization
	void Start() {
		_camera = Camera.main.transform;
		m_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update() {
		if (Menu.menu) {
			return;
		}
		CheckDeath();
		XMovement();
		CheckGrounded();
		CheckJump();
	}
	void CheckDeath() {
		if(transform.position.y < -90) {
			GetComponent<PlayerDeath>().PlayerDie();
		}
	}
	void XMovement() {
		float forward = Input.GetAxis("Vertical");
		float sideward = Input.GetAxis("Horizontal");
		Vector3 movementVector = new Vector3(sideward, 0, forward);
		movementVector = _camera.TransformDirection(movementVector);
		//Debug.DrawRay(transform.position - Vector3.forward * 0.2f, movementVector, Color.red);
		float movement = movementVector.x * moveSpeed;
		m_rigidbody2D.velocity = new Vector2(movement, m_rigidbody2D.velocity.y);
	}
	void CheckGrounded() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position /*- Vector3.up * 0.55f*/, -Vector3.up, 0.6f);
		if (hit) {
			grounded = true;
		} else {
			grounded = false;
		}
	}
	void CheckJump() {
		//if (Input.GetButtonDown("Jump") && grounded) {
		//	_rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		//}
		if (grounded) {
			jetpagTimer = 0;
			if (Input.GetButtonDown("Jump")) {
				jetpagLanded = true;
			}
		}
		if (Input.GetButtonDown("Jump")) {
			jetpagTimer += 0.1f;
		}

		if (Input.GetButton("Jump") && jetpagLanded) {
			if (jetpagTimer < jetpagTime) {
				jetpagTimer += Time.deltaTime;
				m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, jetpagForce);
				fire.SetActive(true);
			} else {
				jetpagLanded = false;
			}
		} else {
			fire.SetActive(false);
		}
	}
}
