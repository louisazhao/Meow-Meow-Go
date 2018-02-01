using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanObjects : MonoBehaviour {
	public GameObject coinPrefab;
	public GameObject[] wave1;
	public GameObject[] wave2;
	public GameObject[] wave3;
	public GameObject[] wave4;


	public int getscore = 0;

	Transform m_transform;



	// Use this for initialization
	void Start () {
		m_transform = this.gameObject.GetComponent<Transform> ();
		getscore = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().score;
		GetWaveLStart (getscore);


		}



	void GetWaveLStart(int sc)
	{	
		//SCORE < 50 , ONLY COIN; 50 <= SCORE < 200, COIN, OBSTCALE, ENERGYBAR; 350> SCORE >= 200, + OBSTCALEWITHCOIN; >= 350
		// + RABIIT; >=500 +WAIL_RABBIT
		if (sc < 50) {
			for (int i = 0; i < 10; i++) {
				
				GameObject go = Instantiate (coinPrefab, GetPosition (), Quaternion.identity);
				go.transform.parent = this.transform;
				go.transform.position = go.transform.position + new Vector3 (0f, 1.2f, 0f);
			}
		} 
		if ((sc >= 50) && (sc < 200)) {
		
			for (int i = 0; i < 10; i++) {
				int randomIndex = Random.Range (0, wave1.Length);
				GameObject go = Instantiate (wave1 [randomIndex], GetPosition (), Quaternion.identity);
				go.transform.parent = this.transform;
				if (randomIndex == 0) {
					go.transform.position = go.transform.position + new Vector3 (0f, 1.2f, 0f);
				} else if (randomIndex == 2) {
					go.transform.position = go.transform.position + new Vector3 (0f, 1.5f, 0f);
				}
			}
		}

		if ((sc >= 200) && (sc < 350)) {
			for (int i = 0; i < 10; i++) {
				int randomIndex = Random.Range (0, wave2.Length);
				GameObject go = Instantiate (wave2 [randomIndex], GetPosition (), Quaternion.identity);
				go.transform.parent = this.transform;
				if (randomIndex == 0) {
					go.transform.position = go.transform.position + new Vector3 (0f, 1.2f, 0f);
				} else if (randomIndex == 2) {
					go.transform.position = go.transform.position + new Vector3 (0f, 1.5f, 0f);
				}
			}
		}
		if ((sc >= 350) && (sc < 500)) {
			for (int i = 0; i < 10; i++) {
				int randomIndex = Random.Range (0, wave3.Length);
				GameObject go = Instantiate (wave3 [randomIndex], GetPosition (), Quaternion.identity);
				go.transform.parent = this.transform;
				if (randomIndex == 0) {
					go.transform.position = go.transform.position + new Vector3 (0f, 1.2f, 0f);
				} else if (randomIndex == 2) {
					go.transform.position = go.transform.position + new Vector3 (0f, 1.5f, 0f);
				}
			}
		}
		if ((sc >= 500)) {
			for (int i = 0; i < 10; i++) {
				int randomIndex = Random.Range (0, wave4.Length);
				GameObject go = Instantiate (wave4 [randomIndex], GetPosition (), Quaternion.identity);
				go.transform.parent = this.transform;
				if (randomIndex == 0) {
					go.transform.position = go.transform.position + new Vector3 (0f, 1.2f, 0f);
				} else if (randomIndex == 2) {
					go.transform.position = go.transform.position + new Vector3 (0f, 1.5f, 0f);
				}
			}
		}

	}

	Vector3 GetPosition()
	{
		Vector3 tempV3 = new Vector3 (0,0,0);
		float tempZ = Random.Range(35f, 185f);
		int tempIn = Random.Range (0, 3);
		// Debug.Log (tempIn);
		if (tempIn == 0) {
			tempV3 = m_transform.position + new Vector3 (-1.5f, 0, tempZ);

		} else if (tempIn == 1) 
		{
			tempV3 = m_transform.position + new Vector3 (0f, 0, tempZ);
		}else if (tempIn == 2) 
		{
			tempV3 = m_transform.position + new Vector3 (1.5f, 0, tempZ);
		}
	
		return tempV3;
	}

}
