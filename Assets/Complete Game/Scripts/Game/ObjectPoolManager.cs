using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PooledObjects
{
	ENEMY_UNAGGRESSIVE = 0,
	ENEMY_AGGRESSIVE,
}

[System.Serializable]
public class ObjectPool
{
	public int poolStartSize;
	public int poolLimit;
	public bool canExpand = false;

	public PooledObjects poolType;
	public GameObject poolObj;

	[HideInInspector]
	public List<GameObject> pooledObjects = new List<GameObject>();

}

public class ObjectPoolManager : MonoBehaviour 
{
	private static ObjectPoolManager mInstance;

	public static ObjectPoolManager Instance
	{
		get
		{
			if (mInstance == null)
			{
				GameObject[] tempObjectList = GameObject.FindGameObjectsWithTag("ObjectPoolManager");

				if (tempObjectList.Length > 1) 
				{
					Debug.LogError ("You have more than 1 Game Manager in the scene");
				}
				else if (tempObjectList.Length == 0)
				{
					// If i can't find a game manager in the game
					GameObject obj = new GameObject("_ObjectPoolManager");
					mInstance = obj.AddComponent<ObjectPoolManager> ();
					obj.tag = "ObjectPoolManager";
				}
				else
				{
					if (tempObjectList[0] != null)
					{
						Debug.Log("Found a Game Manager");
						mInstance = tempObjectList[0].GetComponent<ObjectPoolManager>();
					}

				}
				DontDestroyOnLoad(mInstance.gameObject);
			}
			return mInstance;
		}
	}

	public static ObjectPoolManager CheckInstance ()
	{
		return mInstance;
	}

	public List<ObjectPool> objectPoolList = new List<ObjectPool>();

	// Use this for initialization
	void Start ()
	{
		ObjectPoolManager.CheckInstance();
		//! Spawn everything
		InitializeObjectPools();
	}

	public void InitializeObjectPools()
	{
		for (int i = 0; i < objectPoolList.Count; i++) 
		{
			ObjectPool curPool = objectPoolList[i];
			for (int j = 0; j < curPool.poolStartSize; j++)
			{
				GameObject obj = (GameObject)Instantiate(curPool.poolObj, Vector3.zero, Quaternion.identity);
				curPool.pooledObjects.Add(obj);
				obj.SetActive(false);
				DontDestroyOnLoad(obj);
			}
		}
	}

	//! Get your thing
	public GameObject GetPooledObject(PooledObjects findType)
	{
		for (int i = 0; i < objectPoolList.Count; i++)
		{
			ObjectPool curPool = objectPoolList[i];
			if (curPool.poolType == findType)
			{
				for (int j = 0; j < curPool.pooledObjects.Count; j++)
				{
					if (curPool.pooledObjects[j].activeInHierarchy == false)
					{
						return curPool.pooledObjects[j];
					}
				}

				if (curPool.canExpand == false)
				{
					return null;
				}
				else
				{
					GameObject obj = (GameObject)Instantiate(curPool.poolObj, Vector3.zero, Quaternion.identity);
					curPool.pooledObjects.Add(obj);
					return obj;
				}
			}
		}

		Debug.LogError("Cannot find " + findType + " pool");
		return null;
	}

	// Update is called once per frame
	void Update () 
	{

	}
}
