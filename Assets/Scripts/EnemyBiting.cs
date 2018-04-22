using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBiting : MonoBehaviour {

	[SerializeField] float snappingTime = 0.5f;
	[SerializeField] float moveSpeed = 5;
	[SerializeField] GameObject openMouth;
	[SerializeField] GameObject closedMouth;
	[SerializeField] public Vector3 upVector;
	Transform player;
	float timer;
	bool open;
	// Use this for initialization
	void Start () {
		if(upVector == Vector3.zero) {
			upVector = transform.up;
		}
		timer = snappingTime;
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMouth();
		MoveToPlayer();
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
		transform.LookAt(player, upVector);
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}
}
