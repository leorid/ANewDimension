using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
	public bool destroyOnHitAny;
	bool isDead;
	private void Start() {
		Die die = GetComponent<Die>();
		Die dieP = GetComponentInParent<Die>();
		if (die) {
			die.DieNotifier += OnDeath;
		}
		if (dieP) {
			dieP.DieNotifier += OnDeath;
		}
	}
	void OnDeath() {
		isDead = true;
	}
	private void OnCollisionEnter(Collision collision) {
		if (isDead) {
			return;
		}
		if (collision != null && collision.collider) {
			if(collision.collider.tag == "Player") {
				collision.collider.SendMessage("PlayerDie", SendMessageOptions.DontRequireReceiver);
			}
		}
		if (destroyOnHitAny) {
			Destroy(gameObject);
		}
	}
	private void OnCollisionEnter2D(Collision2D collision) {
		if (isDead) {
			return;
		}
		if (collision != null && collision.collider) {
			if (collision.collider.tag == "Player") {
				collision.collider.SendMessage("PlayerDie", SendMessageOptions.DontRequireReceiver);
			}
		}
		if (destroyOnHitAny) {
			Destroy(gameObject);
		}
	}
}
