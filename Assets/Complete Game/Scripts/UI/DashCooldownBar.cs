using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldownBar : MonoBehaviour {

//	public Animator anim;
//	public bool isDash = true;
//
//	// Use this for initialization
//	void Start () {
//		if(anim == null)
//			anim = GetComponent<Animator>();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		if(Input.GetKeyDown(KeyCode.D) && isDash == true)
//		{
//			//dash action
//			anim.SetTrigger("Dash");
//			isDash = false;
//		}
//	}
//
//	public void SetDashTrue()
//	{
//		isDash = true;
//	}

	RectTransform rectTransform;
	public float currentStamina;
	public float maxStamina;
	public float secondsToRecover;

	public bool alreadyDash = true;

	void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		alreadyDash = true;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Z) && currentStamina >= maxStamina)
		{
			alreadyDash = false;
			currentStamina = 0.0f;
		}

		if(currentStamina < 0.0f)
			currentStamina = 0.0f;
		
		if(currentStamina < maxStamina)
			currentStamina += Mathf.Lerp(0.0f, maxStamina, Time.deltaTime / secondsToRecover);
		else if(currentStamina >= maxStamina)
		{
			currentStamina = maxStamina;
			alreadyDash = true;
		}



		Vector2 newSize = rectTransform.sizeDelta;

		//newSize.x = Mathf.Lerp(12.5f, 295.0f, currentStamina / maxStamina);
		newSize.x = Mathf.Lerp(-150f, 0f, currentStamina / maxStamina);

		rectTransform.sizeDelta = newSize;

	}
}
