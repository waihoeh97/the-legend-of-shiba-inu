using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGate : MonoBehaviour {

	public static FinalGate instance;
	Animator anim;
	public int completedCount;
	public bool finalGateAnimation;

	// Use this for initialization
	void Start () {
		instance = this;
		anim = GetComponent<Animator>();
		completedCount = 0;
	}
	
	// Update is called once per frame
	void Update () {		
		
	}

	public void ChangeSprite()
	{
		if(completedCount < 5)
		{
			completedCount++;
		}
		if(completedCount == 1)
			anim.Play("FinalGateUnlock01");
		else if(completedCount == 2)
			anim.Play("FinalGateUnlock02");
		else if(completedCount == 3)
			anim.Play("FinalGateUnlock03");
		else if(completedCount == 4)
			anim.Play("FinalGateUnlock04");
	}
		
}
