using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PausedManagerScript : MonoBehaviour {

	public GameObject pauseObject;
	public bool canReturn;
	GameObject defaultFocus;

	// Use this for initialization
	void Start () {
		canReturn = true;
		pauseObject = GameObject.FindGameObjectWithTag("PausePopUp");
		defaultFocus = pauseObject.transform.GetChild(1).gameObject;
		pauseObject.SetActive(false);
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Pause();
		}
	}

	public void Pause()
	{
		if(canReturn)
		{
			if(Time.timeScale == 0) 
			{
				Time.timeScale = 1;
				pauseObject.SetActive(false);
			}
			else if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				pauseObject.SetActive(true);
				try {Debug.Log("Before: " + EventSystem.current.currentSelectedGameObject.name);}
				catch{}
				EventSystem.current.SetSelectedGameObject(null);
				try {Debug.Log("Should be Null: " + EventSystem.current.currentSelectedGameObject.name);}
				catch{}
				EventSystem.current.SetSelectedGameObject(defaultFocus);
				try {Debug.Log("After: " + EventSystem.current.currentSelectedGameObject.name);}
				catch{}
			}
		}
	}

	public void SetReturn(bool state)
	{
		canReturn = state;
	}
		
}
