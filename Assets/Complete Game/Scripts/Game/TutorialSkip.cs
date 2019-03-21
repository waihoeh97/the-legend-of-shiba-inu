using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSkip : MonoBehaviour {
	public GameObject Text;
	public PlayerActions player;
	public DashCooldownBar dashBar;
	// Use this for initialization
	void Start () {
		player.enabled = false;
		dashBar.enabled = false;
		Text.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(Text.activeSelf == true)
		{
			if(Input.GetKeyDown(KeyCode.Y))
			{
				Application.LoadLevel(1);
			}

			else if(Input.GetKeyDown(KeyCode.N))
			{
				Text.SetActive(false);
				player.enabled = true;
				dashBar.enabled = true;
			}
		}
	}
}
