using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FocusButton : MonoBehaviour {

	void OnEnable()
	{
		Debug.Log("halo");
		EventSystem.current.SetSelectedGameObject(this.gameObject);
	}

	public void SetButtonActive(GameObject button)
	{
		EventSystem.current.SetSelectedGameObject(button);
	}

	// Use this for initialization
	void Start () {
//		EventSystem.current.SetSelectedGameObject(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
