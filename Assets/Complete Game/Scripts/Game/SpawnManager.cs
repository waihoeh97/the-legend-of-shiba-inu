using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public GameObject gear;
	public GameObject potion;
	public float offsetY = 0.5f;

	private static SpawnManager mInstance;

	public static SpawnManager Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject[] tempObjectList = GameObject.FindGameObjectsWithTag("SpawnManager");

				if(tempObjectList.Length > 1)
				{
					Debug.LogError("You have more than 1 Spawn Manager in the Scene");
				}
				else if(tempObjectList.Length == 0)
				{
					GameObject obj = new GameObject("_SpawnManager");
					mInstance = obj.AddComponent<SpawnManager>();
					obj.tag = "SpawnManager";
				}
				else
				{
					if(tempObjectList[0] != null)
					{
						Debug.Log("Found a Spawn manager");
						mInstance = tempObjectList[0].GetComponent<SpawnManager>();
					}
				}
				DontDestroyOnLoad(mInstance.gameObject);
			}
			return mInstance;
		}
	}

	public static SpawnManager CheckInstanceExist()
	{
		return mInstance;
	}
	

	// Use this for initialization
	void Start () {
		SpawnManager.CheckInstanceExist();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnGear(Vector3 spawnPosition, int value)
	{
		GameObject go = gear;
		go.GetComponent<PuzzleItem>().value = value;
		Vector3 tempPosition = spawnPosition;
		tempPosition.y += offsetY;
		Instantiate(go, tempPosition , Quaternion.identity);
	}

	public void SpawnPotion (Vector3 spawnPosition)
	{
		GameObject go2 = potion;
		Vector3 tempPosition2 = spawnPosition;
		tempPosition2.y += offsetY;
		Instantiate(go2, tempPosition2, Quaternion.identity);
	}
}
