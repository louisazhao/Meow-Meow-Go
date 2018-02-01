using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMove : MonoBehaviour {


	public float speed;


	void Start () {
		speed = 10;
		//this.transform.position =Vector3.MoveTowards(transform.position, new Vector3 (-1.75f,this.transform.position.y,this.transform.position.z), speed*Time.deltaTime);
	}
	

	void FixedUpdate () {
		

		if(this.transform.position.x >= - 1.75f) 
		{
			this.transform.position =Vector3.MoveTowards(transform.position, new Vector3 (1.75f,this.transform.position.y,this.transform.position.z), speed*Time.deltaTime);
		}
		if(this.transform.position.x <=  1.75f) 
		{
			this.transform.position =Vector3.MoveTowards(transform.position, new Vector3 (-1.75f,this.transform.position.y,this.transform.position.z), speed*Time.deltaTime);
		}
	}



}
