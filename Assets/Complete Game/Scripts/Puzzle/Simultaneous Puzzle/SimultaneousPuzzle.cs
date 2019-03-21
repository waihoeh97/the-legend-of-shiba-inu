using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimultaneousPuzzle : MonoBehaviour {
    
	public List<SimultaneousPuzzleArray> platform = new List<SimultaneousPuzzleArray>();

	public bool allStepped = false;
	public Sprite solvedSprite;
	public Transform origin;
	public Transform target;
	public bool isChosen;

	void Update()
	{
		if(!allStepped)
		{
			allStepped = true;
			for(int i = 0; i < platform.Count; i++)
			{
				if(platform[i].platformScript.stepped == false)
				{
					//Debug.Log("All panel is activated");
					allStepped = false;
					break;
				}
			}

			if(allStepped)
			{
				if(isChosen)
				{
					FinalGate.instance.ChangeSprite();
				}
					
				CameraController.Instance.StopAllCoroutines();
				CameraController.Instance.StartCoroutine( CameraController.Instance.CutsceneRoutine( this.target, this.origin) );
			}
		}
	}
}
