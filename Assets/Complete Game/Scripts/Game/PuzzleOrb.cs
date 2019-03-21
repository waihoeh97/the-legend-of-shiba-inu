using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrbType
{
	None,
	Red,
	Blue,
	Yellow
}

public class PuzzleOrb : MonoBehaviour
{
	public OrbType type;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			if(other.GetComponent<PlayerInventory>().heldOrb == OrbType.None)
			{
				other.GetComponent<PlayerInventory>().heldOrb = type;
				Destroy(gameObject);
			}
		}
	}*/
}
