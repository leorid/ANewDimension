using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFinish : MonoBehaviour
{

	public void OnFinish() {
		// load next scene
		Scene currentScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(currentScene.buildIndex+1);
	}


	private void OnCollisionEnter(Collision collision) {
		if (collision != null && collision.collider && collision.collider.tag == "Player") {
			OnFinish();
		}
	}
	private void OnTriggerEnter(Collider other) {
		if (other && other.tag == "Player") {
			OnFinish();
		}
	}
	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision != null && collision.collider && collision.collider.tag == "Player") {
			OnFinish();
		}
	}
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision && collision.tag == "Player") {
			OnFinish();
		}
	}
}
