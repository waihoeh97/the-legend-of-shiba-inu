using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthTemp : MonoBehaviour {

	public const int startingHealth = 3;
	public int currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage (int amount)
	{
		currentHealth -= amount;
		Debug.Log(currentHealth);
	}
}
