using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour {

	private void Update() {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void PlayAgain() {
		SceneManager.LoadScene(0);
	}
}
