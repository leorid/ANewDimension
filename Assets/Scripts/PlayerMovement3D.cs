using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{

	Rigidbody _rigidbody;
	[SerializeField] float gravity = -9.81f;
	[SerializeField] public Vector3 upVector;
	[SerializeField] LayerMask layermask;
	[SerializeField] float moveSpeed = 5;
	[SerializeField] ParticleSystem jetpagMuzzle;
	[SerializeField] bool grounded;
	// Use this for initialization
	void Start() {
		upVector = transform.up;
		_rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {
		if (Menu.menu) {
			return;
		}
		Move();
		CheckGrounded();
		CheckJump();
		if (!grounded) {
			// apply gravity
			_rigidbody.AddForce(upVector * gravity);
		}
	}

	void Move() {
		float xDir = Input.GetAxis("Vertical") * moveSpeed;
		float yDir = Input.GetAxis("Horizontal") * moveSpeed;
		Vector3 localVector = new Vector3(yDir, 0, xDir);
		Vector3 verticalAxis = AbsoluteVector(upVector);
		Vector3 onlyVerticalVelocity = MultiplyVectors(verticalAxis, _rigidbody.velocity);

		localVector = transform.TransformDirection(localVector);
		_rigidbody.velocity = localVector + onlyVerticalVelocity;
	}
	void CheckGrounded() {
		RaycastHit hit;
		Debug.DrawRay(transform.position + upVector * 0.5f, -upVector * 0.6f, Color.red);
		if (Physics.Raycast(transform.position + upVector * 0.5f, -upVector, out hit, 0.6f, layermask)) {
			grounded = true;
		} else {
			grounded = false;
		}
	}

	float jetpagTimer;
	[SerializeField] float jetpagTime = 2;
	bool jetpagLanded = true;
	[SerializeField] float jetpagForce = 2;
	void CheckJump() {
		if (Input.GetButtonDown("Jump")) {
			jetpagTimer += 0.1f;
		}
		if (grounded) {
			jetpagTimer = 0;
			if (Input.GetButtonDown("Jump")) {
				jetpagLanded = true;
			}
		}

		ParticleSystem.EmissionModule emission = jetpagMuzzle.emission;
		if (Input.GetButton("Jump") && jetpagLanded) {
			if (jetpagTimer < jetpagTime) {
				jetpagTimer += Time.deltaTime;
				Vector3 verticalAxis = AbsoluteVector(upVector);
				Vector3 onlyVerticalVelocity = MultiplyVectors(verticalAxis, _rigidbody.velocity);

				// new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, -jetpagForce)
				_rigidbody.velocity += upVector * jetpagForce - onlyVerticalVelocity;

				emission.enabled = true;
			} else {
				jetpagLanded = false;
			}
		} else {
			emission.enabled = false;
		}
	}
	Vector3 AbsoluteVector(Vector3 v1) {
		Vector3 result = v1;
		result.x = Mathf.Abs(result.x);
		result.y = Mathf.Abs(result.y);
		result.z = Mathf.Abs(result.z);
		return result;
	}
	Vector3 MultiplyVectors(Vector3 v1, Vector3 v2) {
		Vector3 result = v1;
		result.x *= v2.x;
		result.y *= v2.y;
		result.z *= v2.z;
		return result;
	}
}
