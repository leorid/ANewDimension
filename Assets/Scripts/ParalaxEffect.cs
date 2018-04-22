using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{

	[SerializeField] Transform player;

	[SerializeField] Transform layer1;
	[SerializeField] Transform layer2;
	[SerializeField] Transform layer3;

	[SerializeField] float globalMulti = 0.01f;
	[SerializeField] float layer1multi = 1;
	[SerializeField] float layer2multi = 0.7f;
	[SerializeField] float layer3multi = 0.5f;

	Vector3 offsetL1;
	Vector3 offsetL2;
	Vector3 offsetL3;
	Vector3 playerStart;
	private void Start() {
		offsetL1 = layer1.position - player.position;
		offsetL2 = layer2.position - player.position;
		offsetL3 = layer3.position - player.position;
		playerStart = player.position;
	}
	// Update is called once per frame
	void Update() {
		Vector3 movement = player.position - playerStart;
		layer1.position = movement * layer1multi * globalMulti + offsetL1;
		layer2.position = movement * layer2multi * globalMulti + offsetL2;
		layer3.position = movement * layer3multi * globalMulti + offsetL3;
	}
}
