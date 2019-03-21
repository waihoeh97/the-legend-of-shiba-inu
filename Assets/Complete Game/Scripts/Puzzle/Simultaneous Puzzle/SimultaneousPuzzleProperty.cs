using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimultaneousPuzzleProperty : MonoBehaviour {
	public Sprite unsolved;
	public Sprite solved;
	public bool stepped = false;
	public SimultaneousPuzzle simulPuzzleManager;
	public CameraTrigger triggerCutsceneOnSolve;

    private void OnTriggerEnter2D(Collider2D target)
    {

		if (target.CompareTag("Player") || target.CompareTag("Boulder"))
        {
			SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_ONPANEL);
			gameObject.GetComponent<SpriteRenderer>().sprite = solved;
			stepped = true;
			if ( triggerCutsceneOnSolve )
			{
				triggerCutsceneOnSolve.TriggerCutscene();
			}
//			Debug.Log("panel is ON");
        }
    }

	private void OnTriggerExit2D(Collider2D target)
	{

		if(target.CompareTag("Player") || target.CompareTag("Boulder"))
		{
			if(simulPuzzleManager.allStepped == true)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = solved;
			}
			else if(simulPuzzleManager.allStepped == false)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = unsolved;
			}

			stepped = false;
		}
	}
}
