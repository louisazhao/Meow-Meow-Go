using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour {

	public int catIndex;
	public GameObject catselector;

	void Awake()
	{
		GameObject.DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		
		catIndex = catselector.GetComponent<CatSelector>().index;
	}




	public void SelectCat()
	{
		catIndex = catselector.GetComponent<CatSelector>().index;
	}
}
