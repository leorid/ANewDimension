using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour {

	PlayerMovement playerMovement;
	protected virtual bool _Grounded {
		get {
			return playerMovement.grounded;
		}
	}
	protected virtual Rigidbody2D _Rigidbody2D {
		get {
			return playerMovement.m_rigidbody2D;
		}
	}
	float currentRotationSpeed = 0;
	[SerializeField] float rotationSpeed = 100;
	// Use this for initialization
	protected virtual void Start () {
		playerMovement = GetComponentInParent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		currentRotationSpeed *= 0.99f;
		if (_Grounded) {
			currentRotationSpeed = _Rigidbody2D.velocity.x * rotationSpeed * Time.deltaTime;
		}

		transform.Rotate(0, 0, -currentRotationSpeed);
	}


}
