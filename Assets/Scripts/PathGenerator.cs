using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PathGenerator : MonoBehaviour {

	public GameObject firstPath;
	Vector3 forwardOffset = new Vector3(0,0,200f);
	int maxPathNum =3;
	public int currPathNum;
	Vector3 startPos;
	Scene sc;

	// Use this for initialization
	void Start () {
		currPathNum = 1;
		startPos = firstPath.GetComponent<Transform> ().position + forwardOffset;
		BuildPath ();

	}
	
	// Update is called once per frame
	void Update () {
		if (currPathNum < maxPathNum) 
		{ 
			BuildPath ();
		}
	}
	void BuildPath()
	{ 
		int y = SceneManager.GetActiveScene ().buildIndex;
		if (y == 2) 
		{
			GameObject go;
			go = Instantiate (firstPath, startPos, Quaternion.Euler(0,180,0));
			startPos = startPos + forwardOffset;

			currPathNum += 1;
		}
		if (y == 3) 
		{
			GameObject go;
			go = Instantiate (firstPath, startPos, Quaternion.identity);
			startPos = startPos + forwardOffset;

			currPathNum += 1;
		}

	}
}
