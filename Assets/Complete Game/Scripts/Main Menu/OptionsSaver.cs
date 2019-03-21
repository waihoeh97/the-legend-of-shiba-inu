using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionsSaver : MonoBehaviour {

	private static OptionsSaver mInstance;

	public static OptionsSaver Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject[] tempObjectList = GameObject.FindGameObjectsWithTag("OptionsSaver");

				if(tempObjectList.Length > 1)
				{
					Debug.LogError("You have more than 1 OptionsSaver in the Scene");
				}
				else if(tempObjectList.Length == 0)
				{
					GameObject obj = new GameObject("OptionsSaver");
					mInstance = obj.AddComponent<OptionsSaver>();
					obj.tag = "OptionsSaver";
				}
				else
				{
					if(tempObjectList[0] != null)
					{
						Debug.Log("Found a OptionsSaver");
						mInstance = tempObjectList[0].GetComponent<OptionsSaver>();
					}
				}
				DontDestroyOnLoad(mInstance.gameObject);
			}
			return mInstance;
		}
	}

	public static OptionsSaver CheckInstanceExist()
	{
		return mInstance;
	}

	GameObject lastselect;
	public Image mask;
	public float brightness;
	public float masterVolume;
	public float sfxVolume;
	Vector3 mousePos = Vector3.zero;

//	void SetCursorState()
//	{
//		mode = CursorLockMode.Locked;
//		Cursor.lockState = mode;
//		Cursor.visible = (CursorLockMode.Locked != mode);
//	}

	void Awake()
	{
//		if(OptionsSaver.CheckInstanceExist())
//		{
//			Debug.Log("deleted");
//			Destroy(this.gameObject);
//		}
	}

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		lastselect = new GameObject();
	}
	
	// Update is called once per frame
	void Update () {
		//Input.mousePosition = mousePos;
		if (EventSystem.current.currentSelectedGameObject == null)
		{
			EventSystem.current.SetSelectedGameObject(lastselect);
		}
		else
		{
			lastselect = EventSystem.current.currentSelectedGameObject;
		}
	}

	public void UpdateSetting()
	{
		mask.color = new Color(0,0,0, 1-brightness);
		SoundManagerScript.Instance.bgmAudioSource.volume = masterVolume;
		SoundManagerScript.Instance.sfxAudioSource.volume = sfxVolume;
	}
}
