using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

	Transform _camera;
	[SerializeField] LineRenderer aimLine; 
	[SerializeField] GameObject bullet;
	[SerializeField] LayerMask aimLayerMask;
	AudioSource shootSound;
	// Use this for initialization
	void Start () {
		_camera = Camera.main.transform;
		shootSound = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void LateUpdate () {
		Plane plane = new Plane(-Vector3.forward, Vector3.zero);
		Ray cameraRay = new Ray(_camera.position, _camera.forward);
		float cameraRayHitDistance;
		if (plane.Raycast(cameraRay, out cameraRayHitDistance)) {
			Vector3 aimPoint = cameraRay.GetPoint(cameraRayHitDistance);
			Vector3 playerAimDirection = aimPoint - transform.position;
			Vector3 hitPoint = aimPoint;

			RaycastHit2D playerHit = Physics2D.Raycast(transform.position, playerAimDirection, playerAimDirection.magnitude, aimLayerMask);
			if (playerHit) {
				hitPoint = playerHit.point;
			}

			if (Input.GetMouseButtonDown(0)) {
				Shoot(playerAimDirection);
			}

			DrawLine(hitPoint);
		}
	}

	void Shoot(Vector3 playerAimDirection) {
		if (Menu.menu) {
			return;
		}
		playerAimDirection.Normalize();
		GameObject newBullet = Instantiate(bullet, transform.position + playerAimDirection * 1.1f, Quaternion.identity);
		newBullet.transform.up = playerAimDirection;
		shootSound.Play();
	}

	void DrawLine(Vector3 hitPoint) {
		aimLine.SetPosition(0, transform.position);
		aimLine.SetPosition(1, hitPoint);
	}
}
