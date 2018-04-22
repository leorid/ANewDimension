using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3D : MonoBehaviour {

	Rigidbody _rigidbody;
	[SerializeField] float speed = 10;
	[SerializeField] float damage = 1;
	[SerializeField] float maxDistance = 30;
	Vector3 startPos;
	private void Start() {
		_rigidbody = GetComponent<Rigidbody>();
		startPos = transform.position;
	}

	private void Update() {
		_rigidbody.velocity = transform.forward * speed;
		float flightDistance = (startPos - transform.position).magnitude;
		if (flightDistance > maxDistance) {
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider collision) {
		collision.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}
}
