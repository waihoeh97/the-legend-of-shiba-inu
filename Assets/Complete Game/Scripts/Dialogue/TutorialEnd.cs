using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnd : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}

	void OnStart()
	{
		Dialogue.Instance.OnAnimationPlay();
	}

	void OnFinish()
	{
		Dialogue.Instance.OnAnimationFinish();
		this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
