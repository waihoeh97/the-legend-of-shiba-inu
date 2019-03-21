using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaymentBox : MonoBehaviour {
	private enum PaymentBoxPuzzle
	{
		SIMULTANEOUS_PUZZLE = 1,
		PILLAR_PUZZLE
	}

	public Sprite paid;
	protected bool simultaneousPuzzle = false;
	void OnTriggerStay2D(Collider2D target)
	{
		if(target.CompareTag("Player"))
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = paid;
				simultaneousPuzzle = true;
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
