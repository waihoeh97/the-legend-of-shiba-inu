using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGate : MonoBehaviour
{	
	public bool hasHorseRelic; //hasRedOrb
	public bool hasArmorRelic; //hasBlueOrb
	public bool hasSwordRelic; //hasYellowOrb
	public PlayerInventory player;

	public List<GameObject> orbSlot = new List<GameObject>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			if(other.GetComponent<PlayerInventory>().heldItem == ItemType.HorseRelic)
			{
				hasHorseRelic = true;
				other.GetComponent<PlayerInventory>().heldItem = ItemType.None;
				orbSlot[0].SetActive(true);
				player.isHolding = false;
				Destroy(player.temp);
			}
			else if(other.GetComponent<PlayerInventory>().heldItem == ItemType.ArmorRelic)
			{
				hasArmorRelic = true;
				other.GetComponent<PlayerInventory>().heldItem = ItemType.None;
				orbSlot[1].SetActive(true);
				player.isHolding = false;
				Destroy(player.temp);

			}
			else if(other.GetComponent<PlayerInventory>().heldItem == ItemType.SwordRelic)
			{
				hasSwordRelic = true;
				other.GetComponent<PlayerInventory>().heldItem = ItemType.None;
				orbSlot[2].SetActive(true);
				player.isHolding = false;
				Destroy(player.temp);

			}

			if(hasHorseRelic && hasArmorRelic && hasSwordRelic)
			{
				Destroy(gameObject);
			}
		}
	}
}
