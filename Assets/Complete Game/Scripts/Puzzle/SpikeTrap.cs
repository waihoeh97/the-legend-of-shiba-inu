using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour {

	float currentTimer;
	float maxTimer = 5;
	// Use this for initialization
	Animator anim;
	BoxCollider2D selfCollider;
	SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		selfCollider = GetComponent<BoxCollider2D>();
		sprite = GetComponent<SpriteRenderer>();
		selfCollider.enabled = false;
		currentTimer = maxTimer;
	}
	
	// Update is called once per frame
	void Update () {
		currentTimer -= Time.smoothDeltaTime;

		if(currentTimer >= 3 && currentTimer <= maxTimer)
		{
			anim.SetInteger("spikeCondition", 0);
			selfCollider.enabled = false;
		}

		else if(currentTimer > 2 && currentTimer < 3 )
		{
			anim.SetInteger("spikeCondition", 1);
		}

		else if(currentTimer > 1 && currentTimer < 2)
		{
			anim.SetInteger("spikeCondition", 2);
			selfCollider.enabled = true;
		}

		else if(currentTimer > 0 && currentTimer <= 1)
		{
			anim.SetInteger("spikeCondition", 3);
		}

		else if(currentTimer <= 0)
		{
			anim.SetInteger("spikeCondition", 0);
			currentTimer = maxTimer;
		}

//		Debug.Log("time = " + currentTimer);
	}
}
