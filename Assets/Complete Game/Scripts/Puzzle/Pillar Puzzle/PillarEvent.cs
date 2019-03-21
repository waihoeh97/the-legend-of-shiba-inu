using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarEvent : MonoBehaviour {

	public List<PuzzlePillar> pillarList; // store the pillar's scirpt
	public List<PuzzleItem> orbList;
	public bool isAllMatched;
	public Transform origin;
	public Transform target;

	// Use this for initialization
	void Start () {
		isAllMatched = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isAllMatched) // only check if not all the pillar are match
		{
			for(int i=0; i<pillarList.Count; i++)
			{
				if(pillarList[i].isMatched == false) //if one of the pillar ismatched is not true, break the loop
				{
					isAllMatched = false;
					break;
				}

				if(i == pillarList.Count-1) // isAllMatch become true when it finish the loop aka the i reach the last index of the list
				{
					isAllMatched = true;
					FinalGate.instance.ChangeSprite();
					CameraController.Instance.StartCoroutine( CameraController.Instance.CutsceneRoutine( this.target, this.origin) );
				}
			}
		}
		else
		{
			Debug.Log("allMatched");//do the event
//			for(int i = 0; i < pillarList.Count; i++)
//			{
//				pillarList[i].gameObject.SetActive(false); //Removes the pillar gameobject
//				orbList[i].gameObject.SetActive(false);
//			}

		}
	}
}
