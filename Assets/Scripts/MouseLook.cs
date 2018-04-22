using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

	Vector3 oldMousePos;

	public float rotationY = 50;

	public float dot1;
	public float dot2;
	[SerializeField] float sensitivity = 3;

	// Use this for initialization
	void Start() {
		oldMousePos = Input.mousePosition;
	}

	// Update is called once per frame
	void Update() {
		if (Menu.menu) {
			return;
		}
		Vector3 mouseDelta = Input.mousePosition - new Vector3(Screen.width, Screen.height) / 2;// - oldMousePos;
		float x = Input.GetAxis("Mouse X") * sensitivity; //mouseDelta.x;
		float y = Input.GetAxis("Mouse Y") * sensitivity; //mouseDelta.y;

		transform.Rotate(-y, 0, 0);
		//transform.RotateAround(transform.parent.position, transform.right, -y);

		dot1 = Vector3.Dot(Vector3.forward, transform.forward);
		dot2 = Vector3.Dot(Vector3.forward, transform.up);
		// || dot2 < 0
		if (dot1 < 0 || dot2 > -0.8f) {
			transform.Rotate(y, 0, 0);
		}

		transform.RotateAround(transform.parent.position, Vector3.forward, -x);
		oldMousePos = Input.mousePosition;

	}
}
