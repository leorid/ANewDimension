using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
	public Vector3 upVector;
	public float distance = 90;
	private void Start() {
		if (upVector == Vector3.zero) {
			upVector = transform.up;
		}
	}
	private void Update() {
		Vector3 onlyVerticalVec = MultiplyVectors(transform.position, AbsoluteVector(upVector));
		float onlyVerticalPos = onlyVerticalVec.x + onlyVerticalVec.y + onlyVerticalVec.z;
		float sign = upVector.x + upVector.y + upVector.z;
		if (onlyVerticalPos * sign < -distance) {
			PlayerDie();
		}
	}
	public void PlayerDie() {
		Scene currentScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(currentScene.buildIndex);
	}

	Vector3 AbsoluteVector(Vector3 v1) {
		Vector3 result = v1;
		result.x = Mathf.Abs(result.x);
		result.y = Mathf.Abs(result.y);
		result.z = Mathf.Abs(result.z);
		return result;
	}
	Vector3 MultiplyVectors(Vector3 v1, Vector3 v2) {
		Vector3 result = v1;
		result.x *= v2.x;
		result.y *= v2.y;
		result.z *= v2.z;
		return result;
	}
}
