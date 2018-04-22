using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim3D : MonoBehaviour {

	Transform camera;
	[SerializeField] GameObject bullet;
	AudioSource shootSound;
	// Use this for initialization
	void Start () {
		camera = Camera.main.transform;
		shootSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Menu.menu) {
			return;
		}
		Vector3 aimPoint = CameraAimPoint();
		if (Input.GetMouseButtonDown(0)) {
			Shoot(aimPoint);
		}
	}

	Vector3 CameraAimPoint() {
		RaycastHit hit;
		Ray cameraRay = new Ray(camera.position, camera.transform.forward);
		if(Physics.Raycast(cameraRay, out hit, 30)) {
			return hit.point;
		} else {
			return cameraRay.GetPoint(30);
		}
	}

	void Shoot(Vector3 aimPoint) {
		Vector3 initPosition = transform.position + transform.up * 0.5f + transform.forward * 0.5f;
		GameObject newBullet = Instantiate(bullet, initPosition, Quaternion.identity);
		newBullet.transform.forward = aimPoint - initPosition;
		shootSound.Play();
	}
}
