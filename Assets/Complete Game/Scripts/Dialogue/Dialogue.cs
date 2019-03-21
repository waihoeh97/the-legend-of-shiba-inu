using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {

	private static Dialogue _instance;
	public static Dialogue Instance { get{ return _instance;}}

	public bool canMove;

	void Awake ()
	{
		if ( _instance == null ) _instance = this;
		else if ( _instance != this ) Destroy(this);
	}

	// Use this for initialization
	void Start () {
		canMove = false;
	}

	public void OnAnimationPlay ()
	{
		canMove = false;
	}

	public void OnAnimationFinish ()
	{
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
