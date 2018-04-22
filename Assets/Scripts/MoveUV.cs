using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUV : MonoBehaviour {

	[SerializeField] Vector2 speed;
	Vector2 currentOffset;
	Renderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		currentOffset += speed * Time.deltaTime;
		renderer.material.SetTextureOffset("_MainTex", currentOffset);
	}
}
