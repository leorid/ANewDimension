using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Rigidbody2D _rigidbody2D;
	[SerializeField] float speed = 10;
	[SerializeField] float damage = 1;
	[SerializeField] float maxDistance = 10;
	[SerializeField] AudioSource audioSource;
	[SerializeField] AudioClip hitWall;
	[SerializeField] AudioClip hitEnemy;
	Vector3 startPos;
	private void Start() {
		_rigidbody2D = GetComponent<Rigidbody2D>();
		startPos = transform.position;
	}

	private void Update() {
		_rigidbody2D.velocity = transform.up * speed;
		float flightDistance = (startPos - transform.position).magnitude;
		if(flightDistance > maxDistance) {
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		collision.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
		audioSource.Play();
		GetComponent<SpriteRenderer>().enabled = false;
		Destroy(this);
		Destroy(gameObject, 0.2f);
	}
}
