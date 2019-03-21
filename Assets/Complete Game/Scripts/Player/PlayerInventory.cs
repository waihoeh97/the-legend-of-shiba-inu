using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	public bool onItem = false;
	public ItemType heldItem;
	public GameObject temp = null;
	public GameObject holdItem = null;
	Vector3 holdItemPosition = Vector3.zero;
	public bool isHolding = false;
	public int gearCount;

	//pillar orb varialbe
	public bool isPillar = false; // to check is within the pillar location
	float offSetY = 0.35f; //offset the y position of the orb while putting the orb
	Vector3 putLocation = Vector3.zero;// position for the orb to stay on the pillar
	PuzzlePillar pillarScript; // store the current pillar script

	// Use this for initialization
	void Start ()
	{
		heldItem = ItemType.None;
		holdItemPosition = transform.position;
	}

	public void UseGear(int amount)
	{
		gearCount -= amount;
	}

	public void AddGear(int amount)
	{
		gearCount += amount;
	}
	
	// Update is called once per frame
	void Update () 
	{
//		Debug.Log("gear = " + gearCount);
		holdItemPosition = transform.position;
		holdItemPosition.y += 0.5f;

		if(Input.GetKeyDown(KeyCode.C))
		{
			if(heldItem != ItemType.None && isHolding == true)
			{
				if(isPillar && pillarScript.currentItem == ItemType.None)//check is within the pillar location
				{
					holdItem.transform.position = putLocation;
					pillarScript.currentItem = heldItem;
					pillarScript.CheckMatch();
				}
				else
				{
					holdItem.transform.position = transform.position;
				}
				heldItem = ItemType.None;
				isHolding = false;
				//temp = null;
				holdItem = null;
			}
			else if(onItem == true && heldItem == ItemType.None && isHolding == false)
			{
				holdItem = temp;
				if(isPillar)
				{
					pillarScript.ClearSlot();
				}
//				if(temp.GetComponent<PuzzleItem>().type == ItemType.Gear)
//				{
				//					gearCount += temp.GetComponent<PuzzleItem>().value;
//				Destroy(temp);
//				}
					heldItem = temp.GetComponent<PuzzleItem>().type;
					//Destroy(temp);
					isHolding = true;
					onItem = false;
				}

		}
		if(isHolding)
		{
			holdItem.transform.position = holdItemPosition;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Item" && isHolding == false)
		{
			onItem = true;
			temp = other.gameObject;
		}

		if(other.tag == "Pillar")
		{
			isPillar = true;
			pillarScript = other.GetComponent<PuzzlePillar>();
			putLocation = other.transform.position; //set the orb location
			putLocation.y += offSetY; // offset the y
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Pillar")
		{
			isPillar = false;
			pillarScript = null;
			putLocation = Vector2.zero; 
		}
		if(other.tag == "Item")
		{
			onItem = false;
			temp = null;
		}
	}
}
