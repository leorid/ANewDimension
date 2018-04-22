using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseLook3DRealWorldView : MonoBehaviour
{
	[SerializeField] float sensitivity = 5;

	private void Start() {

	}

	private void Update() {
		if (Menu.menu) {
			return;
		}
		float xDir = Input.GetAxis("Mouse X") * sensitivity;
		float yDir = Input.GetAxis("Mouse Y") * sensitivity;
		transform.RotateAround(transform.parent.position + transform.parent.up, -transform.parent.right, yDir);
		transform.parent.Rotate(transform.parent.up, xDir, Space.World);
	}
}