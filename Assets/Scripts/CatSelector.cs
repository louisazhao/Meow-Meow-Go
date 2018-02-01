using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSelector : MonoBehaviour {
	public GameObject[] catlist;
	public GameObject[] catnamelist;
	public GameObject leftButton;
	public GameObject rightButton;

	private bool lefton;
	private bool righton;
	public int index;

	// Use this for initialization
	void Start () 
	{
		index = 0;
		leftButton.SetActive (false);
		rightButton.SetActive (true);
		lefton = false;
		righton = true;
		foreach (GameObject go in catlist)
			go.SetActive (false);
		foreach (GameObject go in catnamelist)
			go.SetActive (false);

		catlist [0].SetActive (true);
		catnamelist [0].SetActive (true);
	    
	}
	

	public void ToggleLeft()
	{
		catlist [index].SetActive (false);
		catnamelist [index].SetActive (false);
		index--;
		catlist [index].SetActive (true);
		catnamelist [index].SetActive (true);
		Checkindex ();

	}
	public void ToggleRight()
	{
		catlist [index].SetActive (false);
		catnamelist [index].SetActive (false);
		index++;
		catlist [index].SetActive (true);
		catnamelist [index].SetActive (true);
		Checkindex ();
	}

	private void Checkindex()
	{
		if ((index >= 1) && (!lefton)) {
			leftButton.SetActive (true);
			lefton = true;

		} else if ((index < 1) && (lefton))
		{
			leftButton.SetActive (false);
			lefton = false;

		}

		if ((index > 2) && (righton))
		{
			rightButton.SetActive (false);
			righton = false;

		}else if ((index <= 2) && (!righton))
		{
			rightButton.SetActive (true);
			righton = true;

		}

	}
}
