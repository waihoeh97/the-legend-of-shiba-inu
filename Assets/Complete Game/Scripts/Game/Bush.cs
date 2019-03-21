using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour {
	Animator anim;
	Coroutine bushRef;

	void OnTriggerEnter2D(Collider2D target)
	{
//		Debug.Log(target.tag);
		if (target.CompareTag("PlayerCombo"))
		{
			SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_BUSH);
			bushRef = StartCoroutine(BushEffect());
			SpawnManager.Instance.SpawnPotion(this.transform.position);
		}
	}

	IEnumerator BushEffect()
	{
		anim.enabled = true;
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
		yield return null;

		StopAllCoroutines();
	}

	void Awake()
	{
		anim = GetComponent<Animator>();
		anim.enabled = false;
	}
}
