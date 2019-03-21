using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.CompareTag("Player"))
		{
			Debug.Log("player");
			SceneManager.LoadScene(2);
		}			
	}
}
