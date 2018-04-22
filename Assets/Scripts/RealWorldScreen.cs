using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealWorldScreen : MonoBehaviour {

	[SerializeField] Texture2D[] questioning;
	[SerializeField] Texture2D[] talking;
	[SerializeField] Texture2D[] hit;
	[SerializeField] Texture2D defeated;
	[SerializeField] DamageReceiver damageReceiver;
	[SerializeField] GameObject theInternet;

	[SerializeField] float switchTime = 1;
	float switchTimer;
	Renderer renderer;
	[SerializeField] int bossHealth = 100;
	[SerializeField] int randomIndex;
	bool defeatedStatus = false;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		damageReceiver.OnDamage = OnDamage;
	}
	
	// Update is called once per frame
	void Update () {
		if (defeatedStatus == true) {
			return;
		}
		switchTimer += Time.deltaTime;
		if(switchTimer > switchTime) {
			switchTimer = 0;
			
			randomIndex = Random.Range(0, questioning.Length);
			renderer.material.mainTexture = questioning[randomIndex];
		}
	}

	void OnDamage() {
		switchTimer = 0;
		bossHealth--;
		if(bossHealth <= 0) {
			theInternet.SetActive(true);
			defeatedStatus = true;
			renderer.material.mainTexture = defeated;
		}
		if (defeatedStatus) {
			return;
		}
		int index = Random.Range(0, hit.Length - 1);
		renderer.material.mainTexture = hit[index];
	}

}
