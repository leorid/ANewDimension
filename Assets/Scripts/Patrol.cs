using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

	public bool grounded = false;
	int xDir = 1;
	public Rigidbody2D m_rigidbody2D;
	[SerializeField] float moveSpeed = 2;
	[SerializeField] LayerMask ignoreLayer;

	// Use this for initialization
	void Start() {
		m_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update() {
		grounded = Grounded();
		if (grounded) {
			// move
			m_rigidbody2D.velocity = new Vector2(xDir * moveSpeed, m_rigidbody2D.velocity.y);

			if (TurnAround()) {
				xDir = -xDir;
			}
		}
	}

	bool Grounded() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.55f, ignoreLayer);
		if (hit) {
			return true;
		}
		return false;
	}

	bool TurnAround() {
		RaycastHit2D hitGround = Physics2D.Raycast(transform.position, Vector2.down + Vector2.right * xDir, 0.7f, ignoreLayer);
		RaycastHit2D hitForward = Physics2D.Raycast(transform.position, Vector2.right * xDir, 0.55f, ignoreLayer);
		if (!hitGround || hitForward) {
			return true;
		}
		return false;
	}
}
