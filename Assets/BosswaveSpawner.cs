using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosswaveSpawner : MonoBehaviour
{

	[SerializeField] GameObject enemy;
	[SerializeField] float spawnTime = 10;
	[SerializeField] float spawnTimer;
	[SerializeField] int amount;
	[SerializeField] float distance;
	public List<GameObject> pool;
	// Use this for initialization
	void Start() {
		for (int i = 0; i < amount; i++) {
			GameObject newEnemy = SpawnEnemy();
			newEnemy.SetActive(false);
			pool.Add(newEnemy);
		}
	}

	// Update is called once per frame
	void Update() {
		spawnTimer += Time.deltaTime;
		if (spawnTimer > spawnTime) {
			spawnTimer = 0;
			SpawnWave();
		}
	}

	void SpawnWave() {
		for (int i = 0; i < amount; i++) {
			GameObject spawnedEnemy;
			if (pool.Count > 0) {
				spawnedEnemy = pool[0];
				spawnedEnemy.SetActive(true);
				pool.RemoveAt(0);
			} else {
				spawnedEnemy = SpawnEnemy();
			}
			spawnedEnemy.transform.rotation = transform.rotation;
			spawnedEnemy.transform.position = new Vector3(transform.position.x + transform.right.x * i, transform.position.y, transform.position.z);
		}
	}

	GameObject SpawnEnemy() {
		GameObject spawnedEnemy = Instantiate(enemy, transform);
		spawnedEnemy.GetComponent<Die>().bosswaveSpawner = this;
		spawnedEnemy.GetComponent<EnemyBitingWeak>().maxFlyDistance = distance;
		return spawnedEnemy;
	}
}
