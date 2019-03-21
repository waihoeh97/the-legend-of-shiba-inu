using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBoulder : MonoBehaviour {

	private Transform target;
	public GameObject panel;
	public LayerMask playerLayer;
	public GameObject text;
	bool onPanel;
	bool enablePush;
	float speed = 100f;
	Rigidbody2D rgb;
	Vector3 direction;
	Vector3 blockDirection;

	void OnTriggerStay2D(Collider2D target)
	{
		if(target.CompareTag("Player"))
		{
			if(Input.GetKeyDown(KeyCode.C))
			{
				rgb.velocity = blockDirection * speed * Time.deltaTime;
				enablePush = true;
			}
		}

		if(target.CompareTag("PuzzleSimultaneous"))
		{
			onPanel = true;
			if(transform.position.x >= (target.transform.position.x - 0.05f) && transform.position.x <= (target.transform.position.x + 0.05f))
			{
				Debug.Log("block on panel");
				rgb.velocity = Vector3.zero;
			}
			if(transform.position.y > (target.transform.position.y - 0.01f) && transform.position.y < (target.transform.position.y + 0.01f))
			{
				Debug.Log("block on panel");
				rgb.velocity = Vector3.zero;
			}
		}

		if(target.CompareTag("Wreckage"))
		{
			rgb.velocity = Vector3.zero;
		}

		if(target.CompareTag("Bush"))
		{
			rgb.velocity = Vector3.zero;
		}
	}

	void OnTriggerExit2D(Collider2D target)
	{
		if(target.CompareTag("PuzzleSimultaneous"))
		{
			onPanel = false;
		}

		if(target.CompareTag("Player"))
		{
			enablePush = false;
		}
	}

	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		enablePush = false;
		onPanel = false;
		rgb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		RaycastHit2D hit;
		direction = Vector3.zero;
		float samePosX = transform.position.x;
		float samePosY = transform.position.y;
		if(target.position.y >= (samePosY - 0.2f) && target.position.y <= (samePosY + 0.2f))
		{
//			Debug.Log("same on Y axis");
			if(transform.position.x > target.transform.position.x)
			{
				direction = Vector3.left;
			}
			else if(transform.position.x < target.transform.position.x)
			{
				direction = Vector3.right;
			}
		}

		if(target.position.x >= (samePosX - 0.2f) && target.position.x <= (samePosX + 0.2f))
		{
//			Debug.Log("same on X axis");
			if(transform.position.y > target.transform.position.y)
			{
				direction = Vector3.down;
			}
			else if(transform.position.y < target.transform.position.y)
			{
				direction = Vector3.up;
			}
		}


		blockDirection = -direction;


		hit = Physics2D.Raycast(this.transform.position, direction, 0.5f, playerLayer);
		if(hit.transform != null)
		{
			if(onPanel == false)
			{
				text.SetActive(true);
				if(enablePush == true)
				{
					enablePush = false;
				}
			}
		}
		else if(hit.transform == null)
		{
			text.SetActive(false);
			enablePush = false;
		}
	}
}
