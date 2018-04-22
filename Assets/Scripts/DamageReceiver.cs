using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageReceiver : MonoBehaviour {

	public Action OnDamage;
		
	// Update is called once per frame
	void Damage () {
		if(OnDamage != null) {
			OnDamage();
		}
	}
}
