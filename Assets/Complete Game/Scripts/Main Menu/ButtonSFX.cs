using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSFX : MonoBehaviour, ISelectHandler
{
	public SoundManagerScript.AudioClipID idActivate = SoundManagerScript.AudioClipID.SFX_BUTTONACTIVATED;
	public SoundManagerScript.AudioClipID idMoving = SoundManagerScript.AudioClipID.SFX_BUTTONMOVING;

	// Use this for initialization
	void Start ()
	{
		GetComponent<Button>().onClick.AddListener
		(delegate {SoundManagerScript.Instance.PlaySFX(idActivate);});
	}

	//Do this when the selectable UI object is selected.
	public void OnSelect(BaseEventData eventData)
	{
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
		{
			SoundManagerScript.Instance.PlaySFX(idMoving);
			Debug.Log(this.gameObject.name + " was selected");
		}
	}
}
