using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerEnemy : MonoBehaviour {

	private static SpawnManagerEnemy _instance;
	public static SpawnManagerEnemy Instance { get {return _instance;}}

	public GameObject enemy01;
	public GameObject enemy02;
	public List<TrapRoom> trapRoomList;

	//public int counter = 0;

	public bool isSpawned;

	float S1x1 = 32.0f;
	float S1x2 = 39.0f;
	float S1y1 = 30.0f;
	float S1y2 = 33.0f;

	float S2x1 = 41.0f;
	float S2x2 = 47.0f;
	float S2y1 = 33.0f;
	float S2y2 = 36.0f;

	float S3x1 = 40.2f;
	float S3x2 = 46.8f;
	float S3y1 = 15.0f;
	float S3y2 = 18.0f;

	float S4x1 = 26.5f;
	float S4x2 = 33.0f;
	float S4y1 = 12.4f;
	float S4y2 = 19.2f;

	float S5x1 = 18.4f;
	float S5x2 = 24.3f;
	float S5y1 = 26.8f;
	float S5y2 = 28.8f;

	float S6x1 = 11.0f;
	float S6x2 = 16.0f;
	float S6y1 = 24.8f;
	float S6y2 = 28.0f;

	float S7x1 = 11.6f;
	float S7x2 = 15.5f;
	float S7y1 = 33.3f;
	float S7y2 = 35.4f;

	float S8x1 = 3.0f;
	float S8x2 = 9.0f;
	float S8y1 = 32.0f;
	float S8y2 = 35.5f;

	float S9x1 = 2.5f;
	float S9x2 = 10.0f;
	float S9y1 = 8.0f;
	float S9y2 = 11.7f;

	float S10x1 = 30.8f;
	float S10x2 = 37.0f;
	float S10y1 = 2.8f;
	float S10y2 = 6.0f;

	float S11x1 = 31.2f;
	float S11x2 = 35.5f;
	float S11y1 = 8.9f;
	float S11y2 = 10.3f;

	void Awake ()
	{
		if (_instance == null)
		{
			_instance = this;
		}
		else if (_instance != this)
		{
			Destroy(this);
		}
	}

	// Use this for initialization
	void Start () 
	{
		isSpawned = false;
	}

	//Developer's algorithm
	private void Spawn01 (float x1, float x2, float y1, float y2, int num, bool useTrapRoomIndex, int trapRoomIndex)
	{
		Vector3 spawnArea;

		for (int i = 0; i < num; i++)
		{
			//counter++;
			float randX = Random.Range(x1, x2);
			float randY = Random.Range(y1, y2);
			spawnArea = new Vector3 (randX, randY);
			GameObject go = Instantiate(enemy01, spawnArea, Quaternion.identity);

			if(useTrapRoomIndex)
			{
				trapRoomList[trapRoomIndex].enemyList.Add(go);
			}
			//add the enemy into the trapRoomList[??] enemylist
		}
	}

	//The functions that can be actually used
	public void Spawn01 (float x1, float x2, float y1, float y2, int num, int trapRoomIndex)
	{
		Spawn01(x1, x2, y1, y2, num, true, trapRoomIndex);
	}

	public void Spawn01 (float x1, float x2, float y1, float y2, int num)
	{
		Spawn01(x1, x2, y1, y2, num, false, 0); //trapRoomIndex can be any number (placeholder)
	}

	public void Spawn02 (float x1, float x2, float y1, float y2, int num, bool useTrapRoomIndex, int trapRoomIndex)
	{
		Vector3 spawnArea;

		for (int j = 0; j < num; j++)
		{
			//counter++;
			float randX = Random.Range(x1, x2);
			float randY = Random.Range(y1, y2);
			spawnArea = new Vector3 (randX, randY);
			GameObject go = Instantiate(enemy02, spawnArea, Quaternion.identity);

			if(useTrapRoomIndex)
			{
				trapRoomList[trapRoomIndex].enemyList.Add(go);
			}
			//add the enemy into the trapRoomList[??] enemylist
		}
	}

	//The functions that can be actually used
	public void Spawn02 (float x1, float x2, float y1, float y2, int num, int trapRoomIndex)
	{
		Spawn02(x1, x2, y1, y2, num, true, trapRoomIndex);
	}

	public void Spawn02 (float x1, float x2, float y1, float y2, int num)
	{
		Spawn02(x1, x2, y1, y2, num, false, 0); //trapRoomIndex can be any number (placeholder)
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("SpawnPoint1") && !isSpawned)
		{
			Spawn01(S1x1, S1x2, S1y1, S1y2, 5);
			isSpawned = true;
		}
		if (other.CompareTag("SpawnPoint2") && !isSpawned)
		{
			Spawn01(S2x1, S2x2, S2y1, S2y2, 9);
			Spawn02(S2x1, S2x2, S2y1, S2y2, 1);
			isSpawned = true;
		}
		if (other.CompareTag("SpawnPoint3") && !isSpawned)
		{
			Spawn01(S3x1, S3x2, S3y1, S3y2, 9, 1);
			Spawn02(S3x1, S3x2, S3y1, S3y2, 1, 1);
			isSpawned = true;
		}
		if (other.CompareTag("SpawnPoint4") && !isSpawned)
		{
			Spawn01(S4x1, S4x2, S4y1, S4y2, 5);
			Spawn02(S4x1, S4x2, S4y1, S4y2, 2);
			isSpawned = true;
		}
		if (other.CompareTag("SpawnPoint5") && !isSpawned)
		{
			Spawn01(S5x1, S5x2, S5y1, S5y2, 7);
			isSpawned = true;
		}
		if (other.CompareTag("SpawnPoint6") && !isSpawned)
		{
			Spawn01(S6x1, S6x2, S6y1, S6y2, 9, 0);
			Spawn02(S6x1, S6x2, S6y1, S6y2, 2, 0);
			isSpawned = true;
		}
		if (other.CompareTag("SpawnPoint7") && !isSpawned)
		{
			Spawn01(S7x1, S7x2, S7y1, S7y2, 7);
			isSpawned = true;
		}
		if (other.CompareTag("SpawnPoint8") && !isSpawned)
		{
			Spawn01(S8x1, S8x2, S8y1, S8y2, 4);
			Spawn02(S8x1, S8x2, S8y1, S8y2, 2);
			isSpawned = true;
		}
		if (other.CompareTag("SpawnPoint9") && !isSpawned)
		{
			Spawn01(S9x1, S9x2, S9y1, S9y2, 5);
			Spawn02(S9x1, S9x2, S9y1, S9y2, 3);
			isSpawned = true;
		}
		if (other.CompareTag("SpawnPoint10") && !isSpawned)
		{
			Spawn01(S10x1, S10x2, S10y1, S10y2, 9, 2);
			Spawn02(S10x1, S10x2, S10y1, S10y2, 3, 2);
			isSpawned = true;
		}
		if (other.CompareTag("SpawnPoint11") && !isSpawned)
		{
			Spawn01(S11x1, S11x2, S11y1, S11y2, 3);
			isSpawned = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		isSpawned = false;
	}
}
