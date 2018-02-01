using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataImplementer : MonoBehaviour {

	public GameObject[] catList;
	public GameObject[] spellList;
	public DataHandler dh;
	private int m_index;

	// Use this for initialization
	void Start () {
		

		foreach (GameObject go in catList)
			go.SetActive (false);
		foreach (GameObject go in spellList)
			go.SetActive (false);

		dh = GameObject.FindGameObjectWithTag ("DataHandler").GetComponent<DataHandler>();
		m_index = dh.catIndex;

		catList [m_index].SetActive (true);
		//spellList [m_index].SetActive (true);


	}
	

}
