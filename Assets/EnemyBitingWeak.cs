using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBitingWeak : MonoBehaviour
{

	[SerializeField] float snappingTime = 0.5f;
	[SerializeField] float moveSpeed = 5;
	[SerializeField] public float maxFlyDistance = 60;
	[SerializeField] float flyDistance = 60;
	[SerializeField] GameObject openMouth;
	[SerializeField] GameObject closedMouth;
	[SerializeField] public Vector3 upVector;
	float timer;
	bool open;
	Vector3 startPosition;
	// Use this for initialization
	void Start() {
		if (upVector == Vector3.zero) {
			upVector = transform.up;
		}
		timer = snappingTime;
		startPosition = transform.position;
	}

	// Update is called once per frame
	void Update() {
		UpdateMouth();
		MoveToPlayer();
		UpdateHit();
	}
	void UpdateHit() {
		if (Physics.Raycast(transform.position, transform.forward, 1f)) {
			GetComponent<Die>().Damage(1000);
		}
	}

	void UpdateMouth() {
		timer += Time.deltaTime;
		if (timer > snappingTime) {
			timer = 0;
			open = !open;
			openMouth.SetActive(open);
			closedMouth.SetActive(!open);
		}
	}

	void MoveToPlayer() {
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		flyDistance += moveSpeed * Time.deltaTime;
		if (flyDistance > maxFlyDistance) {
			GetComponent<Die>().Damage(1000);
			flyDistance = 0;
		}
	}
}
