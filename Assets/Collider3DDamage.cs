using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider3DDamage : MonoBehaviour {

	void Damage(float damage) {
		GetComponentInParent<Die>().Damage(damage);
	}
}
