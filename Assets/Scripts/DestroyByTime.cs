using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	public float destroyTime;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = 0;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= destroyTime) {
			Destroy (this.gameObject);
		}
	}
}
