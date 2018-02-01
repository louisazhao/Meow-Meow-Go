using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotaor : MonoBehaviour {
	public float rotatePower;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * rotatePower;

	}
	

}
