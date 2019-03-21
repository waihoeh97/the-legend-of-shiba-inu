using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePillar : MonoBehaviour {

	public List<Sprite> spriteList; //0 not avtivated, 1 is activated but not solve, 2 solved
	SpriteRenderer spr;
	public ItemType slotType;
	public ItemType currentItem; //current holding item
	public bool isMatched;
	// Use this for initialization
	void Start () {
		isMatched = false;
		spr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void ClearSlot() //put here as public function instead of update to avoid checking every frame
	{
		currentItem = ItemType.None;
		spr.sprite = spriteList[0];
	}

	public void CheckMatch() //put here as public function instead of update to avoid checking every frame
	{
		if(slotType == currentItem)
		{
			isMatched = true;
			spr.sprite = spriteList[2];
		}
		else if(slotType != currentItem)
		{
			isMatched = false;
			spr.sprite = spriteList[1];
		}
	}
}
