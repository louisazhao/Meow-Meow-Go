using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private GameObject player;
	private Vector3 offset;

	//shake
	float shakePower = 0.1f;
	float shakeDuration =0.6f;
	float slowDownAmout =1f;
	float initalDuration;
	public bool shouldShake = false;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;
		initalDuration = shakeDuration;
	}

	void LateUpdate () {
		transform.position = player.transform.position + offset;
		if (shouldShake) {
			if (shakeDuration > 0) {
				transform.localPosition = transform.position + Random.insideUnitSphere * shakePower;
				shakeDuration -= Time.deltaTime * slowDownAmout;
			} else {
				
					shouldShake = false;
				shakeDuration = initalDuration;

			}
		}

	}

	public void ShakingCam()
	{
		shouldShake = true;
	}

}
