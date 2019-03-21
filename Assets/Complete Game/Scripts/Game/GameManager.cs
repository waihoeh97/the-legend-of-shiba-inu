using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	private BoardManager boardScript;
//	public GameObject pauseObject

	//private int level = 3;
	void Awake()
	{
		if(instance == null)

			instance = this;

		else if(instance != this)

			Destroy(gameObject);

//		DontDestroyOnLoad(gameObject);
		boardScript = GetComponent<BoardManager>();

		InitGame();
	}

	void Start()
	{
		Debug.Log("Helo");
		Scene curScene = SceneManager.GetActiveScene();
		if(curScene.name == "TryLevel")
		{
			SoundManagerScript.Instance.PlayBGM(SoundManagerScript.AudioClipID.BGM_LEVEL);
		}
		OptionsSaver.Instance.UpdateSetting();

//		Time.timeScale = 1;
		//hidePaused();
	}

	void InitGame()
	{
		boardScript.SetupScene();
//		pauseObject = GameObject.FindGameObjectWithTag("PausePopUp");
//		pauseObject.SetActive(false);
	}

	void Update()
	{
//		if(Input.GetKeyDown(KeyCode.Escape))
//		{
//			if(Time.timeScale == 0) 
//			{
//				Time.timeScale = 1;
//				pauseObject.SetActive(false);
//			}
//			else if(Time.timeScale == 1)
//			{
//				Time.timeScale = 0;
//				pauseObject.SetActive(true);
//			}
//		}
	}
}
