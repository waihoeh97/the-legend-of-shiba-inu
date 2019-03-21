using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeProperties : MonoBehaviour {

	private float speed;

	Transform target;

	Vector3 playerPos;

	//public char animInspector;

	// Use this for initialization
	void Start () 
	{
		target = GameObject.Find("Player").transform;
		playerPos = new Vector3(target.position.x, target.position.y, target.position.z);
		speed = 1;
	}

	// Update is called once per frame
	void Update () 
	{
		transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
		//AttackDirection();
		if (transform.position == playerPos)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
