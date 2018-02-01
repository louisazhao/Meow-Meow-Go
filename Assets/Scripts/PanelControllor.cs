using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControllor : MonoBehaviour {
	
	public GameObject targetPanel;
	bool isActive;
	// Use this for initialization
	void Start () {
		
		targetPanel.SetActive (false);
		isActive = false;
	}
	
	public void ShowPanel()
	{
		if (!isActive)
		{
			targetPanel.SetActive(true);
			isActive = true;
		}
	}

	public void HidePanel()
	{
		if (isActive) 
		{
			targetPanel.SetActive (false);
			isActive = false;
		}
	}
}
