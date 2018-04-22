using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{

	float health = 1;
	[SerializeField] bool dead = false;
	float scaleDownTime = 0.3f;
	float scaleDownTimer = 0;
	public event DieNotifierHandler DieNotifier;
	public delegate void DieNotifierHandler();
	public BosswaveSpawner bosswaveSpawner;

	void Update() {
		if (!dead) {
			return;
		}
		//dead
		scaleDownTimer += Time.deltaTime / scaleDownTime;
		transform.localScale = Vector3.one * Mathf.Lerp(1, 0, scaleDownTimer);
		if (scaleDownTimer >= 1) {
			if (bosswaveSpawner) {
				foreach (MonoBehaviour mb in GetComponents<MonoBehaviour>()) {
					mb.enabled = true;
				}
				gameObject.SetActive(false);
				bosswaveSpawner.pool.Add(gameObject);
				scaleDownTimer = 0;
				dead = false;
				health = 1;
				transform.localScale = Vector3.one;
			} else {
				Destroy(gameObject);
			}
		}
	}

	public void Damage(float damage) {
		health -= damage;
		if (health <= 0) {
			dead = true;
			if (DieNotifier != null && !bosswaveSpawner) {
				DieNotifier();
			}
			foreach (MonoBehaviour mb in GetComponents<MonoBehaviour>()) {
				if (mb != this) {
					mb.enabled = false;
				}
			}
		}
	}
}
