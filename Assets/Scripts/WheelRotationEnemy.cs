using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotationEnemy : WheelRotation
{

	Patrol patrolComponent;
	protected override bool _Grounded {
		get {
			return patrolComponent.grounded;
		}
	}
	protected override Rigidbody2D _Rigidbody2D {
		get {
			return patrolComponent.m_rigidbody2D;
		}
	}
	// Use this for initialization
	protected override void Start() {
		patrolComponent = GetComponentInParent<Patrol>();
	}
}
