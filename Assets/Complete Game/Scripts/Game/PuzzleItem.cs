using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
	None,
	HorseRelic, //Red
	ArmorRelic, // Blue
	SwordRelic, // Yellow
	RedOrb,
	GreenOrb,
	BlueOrb,
	Gear,
	Potion
}

public class PuzzleItem : MonoBehaviour
{
	public ItemType type;
	public int value;
	PlayerInventory playerInvent;
	PlayerProperties playerProperties;
	void Start()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		playerInvent = player.GetComponent<PlayerInventory>();
		playerProperties = player.GetComponent<PlayerProperties>();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			if(this.type == ItemType.Gear)
			{
				SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_PLAYERPICKUPGEAR);
				Destroy(gameObject);
				playerInvent.AddGear(value);
			}
//			if(this.type == ItemType.Potion)
//			{
//				if (playerProperties.currentHealth < playerProperties.startingHealth)
//				{
//					SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_PLAYERPICKUPGEAR);
//					Destroy(gameObject);
//					playerProperties.currentHealth += 1;	
//				}
//			}
		}
	}
}
