using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourUnaggressive : MonoBehaviour {

	[HideInInspector]
	public Vector3 startPos;
	[HideInInspector]
	public Vector3 curVelocity;

	Vector3 prevLocation = Vector3.zero;

	public int randNum;

	float spawnTime;
	float timer = 0.0f;
	public float timeTravelled = 2.0f;
	public float roamRadius = 3.0f;
	public float speed;
	public float currentSpeed;
	public float pauseDuration = 0;

	Animator anim;

	// Use this for initialization
	void Start () 
	{
		spawnTime = Time.time;
		startPos = transform.position;
		anim = GetComponent<Animator> ();
		currentSpeed = speed;
	}

	void Movement ()
	{
		if (Time.time > timer)
		{
			timer = Time.time + timeTravelled;
			randNum = Random.Range(1, 5);
		}

		if (randNum == 1)
		{
			transform.Translate(Vector2.up * currentSpeed * Time.deltaTime);
		}
		else if (randNum == 2)
		{
			transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);
		}
		else if (randNum == 3)
		{
			transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
		}
		else if (randNum == 4)
		{
			transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
		}
	}

	void EnemyAnimation()
	{
		curVelocity = (transform.position - prevLocation) / Time.deltaTime;

		if (curVelocity.x > 0)
		{
			//Debug.Log("Move Right");
			anim.SetBool("isUp", false);
			anim.SetBool("isDown", false);
			anim.SetBool("isLeft", false);
			anim.SetBool("isRight", true);
		}
		if (curVelocity.y > 0)
		{
			//Debug.Log("Move Up");
			anim.SetBool("isUp", true);
			anim.SetBool("isDown", false);
			anim.SetBool("isLeft", false);
			anim.SetBool("isRight", false);
		}
		if (curVelocity.x < 0)
		{
			//Debug.Log("Move Left");
			anim.SetBool("isUp", false);
			anim.SetBool("isDown", false);
			anim.SetBool("isLeft", true);
			anim.SetBool("isRight", false);
		}
		if (curVelocity.y < 0)
		{
			//Debug.Log("Move Down");
			anim.SetBool("isUp", false);
			anim.SetBool("isDown", true);
			anim.SetBool("isLeft", false);
			anim.SetBool("isRight", false);
		}
		prevLocation = transform.position;
	}

	IEnumerator StartActions ()
	{
		yield return null;
		yield return new WaitForSeconds (0.1f);
		Movement();
		EnemyAnimation();
	}

	// Update is called once per frame
	void Update () 
	{
		anim.SetFloat("spawn", spawnTime);
		anim.SetFloat("speed", currentSpeed);
		if (CameraController.Instance.Movement == false)
		{
			StartCoroutine(StartActions());		
		}
	}
}
