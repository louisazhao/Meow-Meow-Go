using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadByScenes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadByIndex(int i)
	{
		SceneManager.LoadScene (i);
	}
	public void Exit()
	{
		Application.Quit ();
	}

}
