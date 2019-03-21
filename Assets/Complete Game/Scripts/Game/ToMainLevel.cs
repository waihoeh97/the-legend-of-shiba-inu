using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void NextLevel()
	{
		SceneManager.LoadScene(3);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
