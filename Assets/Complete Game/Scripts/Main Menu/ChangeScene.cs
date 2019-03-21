using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	AudioClip defaultClip;

	void Awake()
	{
		defaultClip = SoundManagerScript.Instance.ReturnMainMenuClip();
	}

	// Use this for initialization
	void Start () {
		//Cursor.visible = false;
		Scene curScene = SceneManager.GetActiveScene();
		if(curScene.name == "MainMenu" && SoundManagerScript.Instance.bgmAudioSource.clip != defaultClip)
		{
			SoundManagerScript.Instance.PlayBGM(SoundManagerScript.AudioClipID.BGM_MAINMENU);

		}
		OptionsSaver.Instance.UpdateSetting();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void LoadSceneWithIndex(int number)
	{
		SceneManager.LoadScene(number);

		//............LoadScene(number);
		/*if(number == 1)
			Debug.Log("a");
		else if (number == 2)
			Debug.Log("b");*/
	}
}
