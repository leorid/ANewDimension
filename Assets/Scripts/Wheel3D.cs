using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel3D : MonoBehaviour {

	Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponentInParent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(-Vector3.up, _rigidbody.velocity.magnitude);
	}
}
