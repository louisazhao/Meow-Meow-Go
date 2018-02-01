using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

	private Animator anim;
	private int HP;

	void Awake()
	{
		anim = GetComponent<Animator> ();
	}
	void Update () {
		HP = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().currentPlayerHP;
	//	Debug.Log(HP);
		if (HP<=0)
		{
			//Debug.Log ("DEAD!");
			anim.SetTrigger ("GameOver");
		}
	}
}
