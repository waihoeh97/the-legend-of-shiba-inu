using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRoom : MonoBehaviour {

	public List<GameObject> enemyList;
	public GameObject traps;
	public GameObject traps1;
	public bool isActivated;
	public PlayerProperties playerHP;


	// Use this for initialization
	void Start () 
	{
		isActivated = false;
		traps = this.transform.GetChild(0).gameObject;
		traps1 = this.transform.GetChild(1).gameObject;
		traps.SetActive(false);
		traps1.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(traps.activeInHierarchy)
		{
			for(int i = 0; i < enemyList.Count; i++)
			{
				if(enemyList[i] != null)
				{
					//isCleared = false;
					break;
				}
				if(i == enemyList.Count-1)
				{
					//isCleared = true;
					traps.SetActive(false);
					traps1.SetActive(false);
				}

			}
			if (playerHP != null)
			{
				if (playerHP.currentHealth <= 0 && enemyList.Count > 0)
				{
					isActivated = false;
					traps.SetActive(false);
					traps1.SetActive(false);
					enemyList = new List<GameObject>();
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			if(!isActivated)
			{
				traps.SetActive(true);
				traps1.SetActive(true);
				isActivated = true;
			}
		}
	}

//	void OnTriggerExit2D( Collider2D target)
//	{
//		if(target.CompareTag("Player"))
//		{
//			traps.SetActive(false);
//			traps1.SetActive(false);
//		}
//	}
}
