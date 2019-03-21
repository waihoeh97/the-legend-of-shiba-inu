using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManagerScript : MonoBehaviour 
{
	private static SoundManagerScript mInstance;

	public static SoundManagerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject[] tempObjectList = GameObject.FindGameObjectsWithTag("SoundManager");

				if(tempObjectList.Length > 1)
				{
					Debug.LogError("You have more than 1 SoundManager in the Scene");
				}
				else if(tempObjectList.Length == 0)
				{
					GameObject obj = new GameObject("_SoundManager");
					mInstance = obj.AddComponent<SoundManagerScript>();
					obj.tag = "SoundManager";
				}
				else
				{
					if(tempObjectList[0] != null)
					{
						Debug.Log("Found a Sound Manager");
						mInstance = tempObjectList[0].GetComponent<SoundManagerScript>();
					}
				}
				DontDestroyOnLoad(mInstance.gameObject);
			}
			return mInstance;
		}
	}

	public static SoundManagerScript CheckInstanceExist()
	{
		return mInstance;
	}

	public enum AudioClipID
	{
		SFX_PLAYERATTACK = 0,
		SFX_PLAYERPICKUPGEAR,
		SFX_ENEMYATTACK,
		SFX_ENEMYDEATH,
		SFX_PLAYERDASH,
		SFX_PUSHBLOCK,
		SFX_ONPANEL,
		SFX_BUSH,
		SFX_PLAYERDEATH,
		SFX_GEARPAID,
		SFX_GATEOPEN,
		SFX_WALKING,
		SFX_BUTTONACTIVATED,
		SFX_BUTTONMOVING,




		BGM_MAINMENU = 99,
		BGM_LEVEL,
	}

	[System.Serializable]
	public class AudioClipInfo
	{
		public AudioClipID audioID;
		public AudioClip audioClip;
	}

	public List<AudioClipInfo> audioClipList = new List<AudioClipInfo>();

	public AudioSource sfxAudioSource;
	public AudioSource bgmAudioSource;

	public float sfxVolume;
	public float bgmVolume;

	void Awake()
	{
//		if(!SoundManagerScript.CheckInstanceExist())
//		{
//			Destroy(this.gameObject);
//		}
	}

	// Use this for initialization
	void Start ()
	{
//		if(SoundManagerScript.CheckInstanceExist())
//		{
//			Destroy(this.gameObject);
//		}
//		Debug.Log(Instance.gameObject.name);
		//DontDestroyOnLoad(mInstance.gameObject);
	}

	AudioClip FindAudioClip(AudioClipID audioID)
	{
		for(int i = 0; i < audioClipList.Count; i++)
		{
			if(audioClipList[i].audioID == audioID)
			{
				return audioClipList[i].audioClip;
			}
		}

		Debug.LogError("Cannot find audioClip : " + audioID);
		return null;
	}

	//! BGM Functions
	public void PlayBGM(AudioClipID bgmAudioID)
	{
		bgmAudioSource.volume = bgmVolume;
		bgmAudioSource.clip = FindAudioClip(bgmAudioID);
		bgmAudioSource.loop = true;
		bgmAudioSource.Play();
	}

	public void PauseBGM()
	{
		if(bgmAudioSource.isPlaying)
		{
			bgmAudioSource.Pause();
		}
		else
		{
			bgmAudioSource.UnPause();
		}
	}

	public void StopBGM()
	{
		if(bgmAudioSource.isPlaying)
		{
			bgmAudioSource.Stop();
		}
		else 
		{
			bgmAudioSource.Play();
		}
	}

	//! SFX Functions
	public void PlaySFX(AudioClipID sfxAudioID)
	{
		sfxAudioSource.PlayOneShot(FindAudioClip(sfxAudioID), sfxVolume);
	}

	public void StopSFX()
	{

	}

	// Update is called once per frame
	void Update () 
	{
		
	}

	public AudioClip ReturnMainMenuClip()
	{
		return FindAudioClip(AudioClipID.BGM_MAINMENU);
	}
}
