using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour {

	private static TriggerDialogue _instance;
	public static TriggerDialogue Instance { get{return _instance;}}

	public bool Transition;

	void Awake ()
	{
		if ( _instance == null ) _instance = this;
		else if ( _instance != this ) Destroy(this);
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.CompareTag("Player"))
		{
			Transition = true;	
		}
	}
}
