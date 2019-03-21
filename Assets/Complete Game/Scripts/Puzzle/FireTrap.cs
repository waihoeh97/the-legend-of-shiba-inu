using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour {
	public Sprite harmlessFire;
	float currentTimer;
	float maxTimer = 5;
	// Use this for initialization
	Animator anim;
	BoxCollider2D selfCollider;

	void Start () {
		GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		selfCollider = GetComponent<BoxCollider2D>();
		selfCollider.enabled = false;
		currentTimer = maxTimer;
	}
	
	// Update is called once per frame
	void Update () {
		currentTimer -= Time.smoothDeltaTime;

		if(currentTimer >= 4 && currentTimer <= maxTimer)
		{
			anim.SetInteger("fireCondition", 0);
			selfCollider.enabled = false;
		}

		else if(currentTimer >= 3 && currentTimer < 4 )
		{
			anim.SetInteger("fireCondition", 1);
		}
		else if(currentTimer > 0 && currentTimer < 3)
		{
			anim.SetInteger("fireCondition", 2);
			selfCollider.enabled = true;
		}
		else if(currentTimer <= 0)
		{
			currentTimer = maxTimer;
		}
	}
}
