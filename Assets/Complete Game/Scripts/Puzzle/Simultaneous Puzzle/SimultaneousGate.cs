using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimultaneousGate : MonoBehaviour {
//	public Sprite gateOpen;
	public SimultaneousPuzzle simultaneousPuzzle;
	public GameObject text;
	public GameObject target;
	public BoxCollider2D selfCollider;
	PlayerInventory playerInvent;
	Animator anim;
	bool alreadyPaid;
	Coroutine gateOpenRef;

	private void Start()
	{
		selfCollider = gameObject.GetComponent<BoxCollider2D>();
		playerInvent = target.GetComponent<PlayerInventory>();
		anim = GetComponent<Animator>();
		alreadyPaid = false;
		text.SetActive(false);
	}

	void OnTriggerStay2D(Collider2D target)
	{
		if(target.CompareTag("Player"))
		{
			if(alreadyPaid == false)
			{
				text.SetActive(true);
			}
//			Debug.Log("available to pay");
			if(Input.GetKeyDown(KeyCode.C))
			{
				if(playerInvent.gearCount >= 40 && alreadyPaid == false)
				{
					SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_GEARPAID);
					playerInvent.UseGear(40);
//					Debug.Log("gear paid");
					anim.SetInteger("GateOpen", 1);
					alreadyPaid = true;
					anim.Play("FinalGateUnlocking");
					text.SetActive(false);
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D target)
	{
		if(target.CompareTag("Player"))
		{
			text.SetActive(false);
		}
	}

	IEnumerator GateOpen()
	{
		anim.SetInteger("GateOpen", 2);
		yield return new WaitForSeconds(1f);
		selfCollider.enabled = false;

		yield return null;
		StopAllCoroutines();
	}

	private void Update()
	{
		if(simultaneousPuzzle.allStepped == true)
		{
			anim.SetBool("onPanelUnpaid", true);
			if(alreadyPaid == true)
			{
				gateOpenRef = StartCoroutine(GateOpen());
				anim.Play("FinalGateOpening");
			}
//			Debug.Log("Puzzle is solved");
		}

		else
		{
			anim.SetBool("onPanelUnpaid", false);
		}

//		Debug.Log("alreadyPaid = " + alreadyPaid);

	}

	public void GateOpenSound()
	{
		SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_GATEOPEN);

	}
}
