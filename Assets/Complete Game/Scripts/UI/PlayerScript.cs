using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public int health = 3;
	int healthMax;

	public List<GameObject> hpImages;

	// Use this for initialization
	void Start () 
	{
		healthMax = health;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.S))
		{
			health--;
			if(health < 0)
			{
				health = 0;

			}
		}
		else if(Input.GetKeyDown(KeyCode.A))
		{
			health++;
			if(health >= healthMax)
			{
				health = healthMax;
			}
		}

		UpdateHpBar ();
	}

	void UpdateHpBar()
	{
//		if (health == 3) {
//			hpImages [0].SetActive (true);
//			hpImages [1].SetActive (true);
//			hpImages [2].SetActive (true);
//		}
//		else if (health == 2) {
//			hpImages [0].SetActive (true);
//			hpImages [1].SetActive (true);
//			hpImages [2].SetActive (false);
//		}
//		else if (health == 1) {
//			hpImages [0].SetActive (true);
//			hpImages [1].SetActive (false);
//			hpImages [2].SetActive (false);
//		}
//		else if (health == 0) {
//			hpImages [0].SetActive (false);
//			hpImages [1].SetActive (false);
//			hpImages [2].SetActive (false);
//		}
//
//
//		//Refactor
//		if(health > 0)
//			hpImages[0].SetActive(true);
//
//		if(health > 1)
//			hpImages[1].SetActive(true);
//		else
//			hpImages[1].SetActive(false);
//
//		if(health > 2)
//			hpImages[2].SetActive(true);
//
		//Refactor
		for (int i = 0; i < healthMax; i++)
		{
//			if (health > i)
//			{
//				hpImages [i].SetActive (true);
//			}
//			else
//			{
//				hpImages [i].SetActive (false);
//			}
			hpImages [i].SetActive (health > i);
		}
	}
}