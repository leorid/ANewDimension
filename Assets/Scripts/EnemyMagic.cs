using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagic : MonoBehaviour
{

	Transform player;
	[SerializeField] float creationTime = 3;
	[SerializeField] LayerMask layerMask;
	float creationTimer;
	[SerializeField] GameObject creationObject;
	GameObject currentCreation;
	[SerializeField] Vector3 upVector;
	bool spawning = false;
	[SerializeField] float distance;
	[SerializeField] float minDistance = 30;

	// Use this for initialization
	void Start() {
		upVector = transform.up;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		GetComponent<Die>().DieNotifier += OnDie;
		currentCreation = GetNewCreation();
		RaycastHit floorHit;
		if (Physics.Raycast(transform.position + upVector, -upVector, out floorHit, layerMask)) {
			transform.position = floorHit.point;
		}
	}

	// Update is called once per frame
	void Update() {
		distance = (player.position - transform.position).magnitude;
		if(!spawning && distance < minDistance) {
			spawning = true;
		}
		if (spawning) {
			transform.LookAt(player, upVector);
			creationTimer += Time.deltaTime;
			currentCreation.transform.localScale = Vector3.one * creationTimer / creationTime;
			if (creationTimer > creationTime) {
				creationTimer = 0;
				NextCreation();
			}
		}
	}
	void NextCreation() {
		ManageMonoBehaviours(currentCreation, true);
		currentCreation = GetNewCreation();
		spawning = false;
	}
	GameObject GetNewCreation() {
		GameObject newCreation;
		newCreation = Instantiate(creationObject, transform);
		newCreation.transform.position = transform.position + upVector * 3;
		newCreation.transform.localScale = Vector3.one * 0.001f;
		newCreation.transform.forward = transform.forward;
		newCreation.GetComponent<EnemyBiting>().upVector = upVector;
		ManageMonoBehaviours(newCreation, false);
		return newCreation;
	}

	void ManageMonoBehaviours(GameObject source, bool enabled) {
		foreach (MonoBehaviour mb in source.GetComponents<MonoBehaviour>()) {
			mb.enabled = enabled;
		}
	}

	void OnDie() {
		foreach (Die childDie in GetComponentsInChildren<Die>()) {
			if (childDie.gameObject != gameObject && childDie.enabled) {
				childDie.transform.SetParent(transform.parent);
			}
		}
	}
}
